using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrafficControlSystem.Models;

namespace TrafficControlSystem
{
    public delegate void UIEvent(Intersection intersection);

    public class UISyncObject
    {
        public event UIEvent OnTimeToUpdate;

        public void TimeToUpdate(Intersection intersection)
        {
            if (OnTimeToUpdate != null)
                OnTimeToUpdate(intersection);
        }
    }

    public class IntersectionController
    {
        private Intersection intersection;
        private DateTime startTime;
        
        Thread uiThread;
        UISyncObject syncObject = new UISyncObject();

        public IntersectionController(Intersection intersection)
        {
            this.intersection = intersection;            
        }

        public void Run(TimeSpan duration)
        {
            startTime = DateTime.Now;
            Console.WriteLine($"Running simulation for {intersection.Description}");

            syncObject = new UISyncObject();


            uiThread = new Thread(new ParameterizedThreadStart((s) =>
            {
                Form1 mygui = new Form1((UISyncObject)syncObject);
                Application.Run(mygui);
            }));

            uiThread.Start(syncObject);
            
            int currentTimingGroupIndex = 0;

            while (DateTime.Now < startTime.Add(duration))
            {
                HandleTimingGroup(intersection.TimingGroups[currentTimingGroupIndex]);

                if (++currentTimingGroupIndex == intersection.TimingGroups.Count)
                    currentTimingGroupIndex = 0;
            }
        }

        private void HandleTimingGroup(TimingGroup timingGroup)
        {
            int currentTimingIndex = timingGroup.Timings.Min(t => t.Order);

            while (currentTimingIndex <= timingGroup.Timings.Count)
            {
                var timing = timingGroup.Timings.Single(t => t.Order == currentTimingIndex);
                SetSignalGroupsColor(timingGroup.SignalGroups, timing.Light);
                intersection.OutputCurrentState();
                System.Threading.Thread.Sleep(timing.Duration * 1000);
                currentTimingIndex++;
            }
            
            //ensure all are set to red before proceeding
            //SetAllToRed();
        }

        private void SetSignalGroupsColor(List<SignalGroup> signalGroups, LightColor newLightColor)
        {
            signalGroups.ForEach(signalGroup =>
            {
                SetSignalGroupColor(signalGroup, newLightColor);
            });
        }

        private void SetSignalGroupColor(SignalGroup signalGroup, LightColor newLightColor)
        {
            signalGroup.Signals.ForEach(signal =>
            {
                signal.CurrentLight = newLightColor;
            });
            syncObject.TimeToUpdate(intersection);
        }

        private void SetAllToRed()
        {
            intersection.SignalGroups.ForEach(signalGroup =>
            {
                SetSignalGroupColor(signalGroup, LightColor.Red);
            });
        }
    }
}
