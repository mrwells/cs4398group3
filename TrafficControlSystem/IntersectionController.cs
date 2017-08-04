using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrafficControlSystem.Models;

namespace TrafficControlSystem
{
    public delegate void UIEvent(Intersection intersection, int countdown);

    public class UISyncObject
    {
        public event UIEvent OnTimeToUpdate;

        public void TimeToUpdate(Intersection intersection, int countdown)
        {
            if (OnTimeToUpdate != null)
                OnTimeToUpdate(intersection, countdown);
        }
    }
	
    /// <summary>
    /// IntersectionController Class
    /// </summary>
    /// <remarks>
    /// IntersectionController Class has 2 attributes:
    /// (Intersection) intersection - An Intersection
    /// (DateTime) startTime - Start Time of Simulation</remarks>
    public class IntersectionController
    {
        private Intersection intersection;
        private DateTime startTime;
        private int countdownindex;
        
        Thread uiThread;
        UISyncObject syncObject;

        /// <summary>
        /// 
        /// </summary>
        public int countdown
        {
            get { return countdownindex; }
        }

        /// <summary>
        /// Constructor for IntersectionController
        /// </summary>
        /// <remarks>
        /// Creates a new Intersection using the passed parameter.
        /// </remarks>
        /// <param name="intersection">The Intersection to use for the simulator.</param>
        public IntersectionController(Intersection intersection)
        {
            this.intersection = intersection;
            syncObject = new UISyncObject();            
        }

        /// <summary>
        /// Entry point for the simulation.  
        /// Executes the intersection configuration provided in the constructor.
        /// </summary>
        /// <param name="duration">Length of time to run simulation</param>
        public void Run(TimeSpan duration)
        {
            startTime = DateTime.Now;
            Console.WriteLine($"Running simulation for {intersection.Description}");

            uiThread = new Thread(new ParameterizedThreadStart((s) =>
            {
                Form1 mygui = new Form1((UISyncObject)s);
                Application.Run(mygui);
            }));

            uiThread.Start(syncObject);

            System.Threading.Thread.Sleep(500);

            int currentTimingGroupIndex = 0;

            while (DateTime.Now < startTime.Add(duration))
            {
                HandleTimingGroup(intersection.TimingGroups[currentTimingGroupIndex]);

                if (++currentTimingGroupIndex == intersection.TimingGroups.Count)
                    currentTimingGroupIndex = 0;
            }
        }

        /// <summary>
        /// Execute the timing cycle for a group of lights
        /// </summary>
        /// <param name="timingGroup">The timing group to act on</param>
        private void HandleTimingGroup(TimingGroup timingGroup)
        {
            int currentTimingIndex = timingGroup.Timings.Min(t => t.Order);
                       
            while (currentTimingIndex <= timingGroup.Timings.Count)
            {
                var timing = timingGroup.Timings.Single(t => t.Order == currentTimingIndex);
                countdownindex = timing.Duration;
                syncObject.TimeToUpdate(intersection, countdownindex);
                SetSignalGroupsColor(timingGroup.SignalGroups, timing.Light, countdownindex);
                intersection.OutputCurrentState();
                int temp = timing.Duration;
                while (countdownindex > 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    countdownindex--;
                    syncObject.TimeToUpdate(intersection, countdownindex);

                }
                //System.Threading.Thread.Sleep(timing.Duration * 1000);
                currentTimingIndex++;
                                
            }
            
            //ensure all are set to red before proceeding
            //SetAllToRed();
        }

        /// <summary>
        /// Change the current light color for groups of signals
        /// </summary>
        /// <param name="signalGroups">The signals to act on</param>
        /// <param name="newLightColor">The color to change to</param>
        public void SetSignalGroupsColor(List<SignalGroup> signalGroups, LightColor newLightColor, int count)
        {
            signalGroups.ForEach(signalGroup =>
            {
                SetSignalGroupColor(signalGroup, newLightColor);
            });
            syncObject.TimeToUpdate(intersection, count);
        }

        /// <summary>
        /// Change the current light color for a group of signals
        /// </summary>
        /// <param name="signalGroup">The signals to act on</param>
        /// <param name="newLightColor">The color to change to</param>
        public void SetSignalGroupColor(SignalGroup signalGroup, LightColor newLightColor)
        {
            signalGroup.Signals.ForEach(signal =>
            {
                signal.CurrentLight = newLightColor;
            });
        }

        /// <summary>
        /// Reset all lights to red
        /// </summary>
        public void SetAllToRed()
        {
            SetSignalGroupsColor(intersection.SignalGroups, LightColor.Red, 3);
        }
    }
}
