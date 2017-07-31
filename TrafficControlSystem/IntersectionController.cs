using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TrafficControlSystem.Models;

namespace TrafficControlSystem
{
    public class IntersectionController
    {
        private Intersection intersection;
        private DateTime startTime;
        Form1 mygui = new Form1();

        public IntersectionController(Intersection intersection)
        {
            this.intersection = intersection;
        }

        public void Run(TimeSpan duration)
        {
            startTime = DateTime.Now;
            Console.WriteLine($"Running simulation for {intersection.Description}");

            
            mygui.Show();
            mygui.Refresh();

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
                
                if (signalGroup.Id == "universityblvd_east" || signalGroup.Id == "universityblvd_east")
                {
                    if (newLightColor == LightColor.Green)
                    {
                        mygui.label21.Visible = true;
                        mygui.label18.Visible = true;
                        mygui.label27.Visible = true;
                        mygui.label30.Visible = true;
                        mygui.label17.Visible = false;
                        mygui.label20.Visible = false;
                        mygui.label26.Visible = false;
                        mygui.label29.Visible = false;
                        mygui.label16.Visible = false;
                        mygui.label19.Visible = false;
                        mygui.label25.Visible = false;
                        mygui.label28.Visible = false;
                        mygui.Refresh();
                    }
                    if (newLightColor == LightColor.Yellow)
                    {
                        mygui.label21.Visible = false;
                        mygui.label18.Visible = false;
                        mygui.label27.Visible = false;
                        mygui.label30.Visible = false;
                        mygui.label17.Visible = true;
                        mygui.label20.Visible = true;
                        mygui.label26.Visible = true;
                        mygui.label29.Visible = true;
                        mygui.label16.Visible = false;
                        mygui.label19.Visible = false;
                        mygui.label25.Visible = false;
                        mygui.label28.Visible = false;
                        mygui.Refresh();
                    }
                    if (newLightColor == LightColor.Red)
                    {
                        mygui.label21.Visible = false;
                        mygui.label18.Visible = false;
                        mygui.label27.Visible = false;
                        mygui.label30.Visible = false;
                        mygui.label17.Visible = false;
                        mygui.label20.Visible = false;
                        mygui.label26.Visible = false;
                        mygui.label29.Visible = false;
                        mygui.label16.Visible = true;
                        mygui.label19.Visible = true;
                        mygui.label25.Visible = true;
                        mygui.label28.Visible = true;
                        mygui.Refresh();
                    }
                }

                if (signalGroup.Id == "universityblvd_turnlanes")
                {
                    if (newLightColor == LightColor.GreenArrow)
                    {
                        mygui.label13.Visible = false;
                        mygui.label14.Visible = false;
                        mygui.label15.Visible = true;
                        mygui.label34.Visible = false;
                        mygui.label35.Visible = false;
                        mygui.label36.Visible = true;
                        mygui.Refresh();
                    }
                    if (newLightColor == LightColor.YellowArrow)
                    {
                        mygui.label13.Visible = false;
                        mygui.label14.Visible = true;
                        mygui.label15.Visible = false;
                        mygui.label34.Visible = false;
                        mygui.label35.Visible = true;
                        mygui.label36.Visible = false;
                        mygui.Refresh();
                    }
                    if (newLightColor == LightColor.RedArrow)
                    {
                        mygui.label13.Visible = true;
                        mygui.label14.Visible = false;
                        mygui.label15.Visible = false;
                        mygui.label34.Visible = true;
                        mygui.label35.Visible = false;
                        mygui.label36.Visible = false;
                        mygui.Refresh();
                    }
                }

                if (signalGroup.Id.Contains("sunrise"))
                {
                    if (newLightColor == LightColor.Green)
                    {
                        mygui.label3.Visible = true;
                        mygui.label4.Visible = true;
                        mygui.label7.Visible = true;
                        mygui.label31.Visible = true;
                        mygui.label2.Visible = false;
                        mygui.label5.Visible = false;
                        mygui.label8.Visible = false;
                        mygui.label32.Visible = false;
                        mygui.label1.Visible = false;
                        mygui.label6.Visible = false;
                        mygui.label9.Visible = false;
                        mygui.label33.Visible = false;
                        mygui.Refresh();
                    }
                    if (newLightColor == LightColor.Yellow)
                    {
                        mygui.label3.Visible = false;
                        mygui.label4.Visible = false;
                        mygui.label7.Visible = false;
                        mygui.label31.Visible = false;
                        mygui.label2.Visible = true;
                        mygui.label5.Visible = true;
                        mygui.label8.Visible = true;
                        mygui.label32.Visible = true;
                        mygui.label1.Visible = false;
                        mygui.label6.Visible = false;
                        mygui.label9.Visible = false;
                        mygui.label33.Visible = false;
                        mygui.Refresh();
                    }
                    if (newLightColor == LightColor.Red)
                    {
                        mygui.label3.Visible = false;
                        mygui.label4.Visible = false;
                        mygui.label7.Visible = false;
                        mygui.label31.Visible = false;
                        mygui.label2.Visible = false;
                        mygui.label5.Visible = false;
                        mygui.label8.Visible = false;
                        mygui.label32.Visible = false;
                        mygui.label1.Visible = true;
                        mygui.label6.Visible = true;
                        mygui.label9.Visible = true;
                        mygui.label33.Visible = true;
                        mygui.Refresh();
                    }
                }


            });
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
