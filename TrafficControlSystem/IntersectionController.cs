using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficControlSystem
{
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

        public bool[] crosswalkButtonPressed = new bool[] {false, false } ;
        
        Thread uiThread;
        UISyncObject syncObject;

      

        /// <summary>
        /// Constructor for IntersectionController
        /// </summary>
        /// <remarks>
        /// Creates a new Intersection using the passed parameter.
        /// </remarks>
        /// <param name="intersection">The Intersection object to use for the system.</param>
        public IntersectionController(Intersection intersection)
        {
            this.intersection = intersection;
            syncObject = new UISyncObject();

            syncObject.CrosswalkPressed_EastWest += SyncObject_CrosswalkPressed;
        }

        private void SyncObject_CrosswalkPressed(Roadway roadway)
        {
           
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
                IntersectionView mygui = new IntersectionView((UISyncObject)s);
                Application.Run(mygui);
            }));

            uiThread.Start(syncObject);

            Thread.Sleep(1000);

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

            int timingGroupTotalTime = timingGroup.Timings.Where(tg => tg.Light == LightColor.Green).Sum(tg => tg.Duration) * 1000;
            //int timingGroupTotalTime = timingGroup.Timings.Where(tg => tg.Light == LightColor.Green || tg.Light == LightColor.Yellow).Sum(tg => tg.Duration) * 1000;
            int timingGroupTimeRemaining = timingGroupTotalTime;

            bool shortTimeRemaining = timingGroupTotalTime <= 5000;

            while (currentTimingIndex <= timingGroup.Timings.Count)
            {
                var timing = timingGroup.Timings.Single(t => t.Order == currentTimingIndex);

                var timeRemaining = timing.Duration * 1000;

                SetSignalGroupsColor(timingGroup.SignalGroups, timing.Light);
                intersection.OutputCurrentState();
                
                while (timeRemaining >= 0)
                {
                    //update state and UI every 500ms

                    intersection.SignalGroups.ForEach(signalGroup =>
                    {
                        if (timingGroup.SignalGroups.Select(s => s.Roadway).ToList().Contains(signalGroup.Roadway))
                        {
                            //this signalGroup IS in the current timingGroup
                            //it's crosswalks should be red
                            ToggleCrossWalks(signalGroup, false, shortTimeRemaining, timingGroupTimeRemaining);
                        }
                        else if (timing.Light == LightColor.GreenArrow ||
                                 timing.Light == LightColor.YellowArrow ||
                                 timing.Light == LightColor.RedArrow ||
                                 timing.Light == LightColor.Red)
                        {
                            //this signalgroup is NOT in the current timingGroup
                            //but the current lights suggest that the crosswalk should be red
                            ToggleCrossWalks(signalGroup, false, shortTimeRemaining, timingGroupTimeRemaining);
                        }
                        else if (timingGroupTimeRemaining <= 0)
                        {
                            //this signalgroup is NOT in the current timingGroup
                            //and there's not time remaining
                            ToggleCrossWalks(signalGroup, false, shortTimeRemaining, timingGroupTimeRemaining);

                            //reset so we dont constantly have a walk
                            if (signalGroup == intersection.SignalGroups[3] || signalGroup == intersection.SignalGroups[4])
                                syncObject.crosswalkPressed[0] = false;
                            else if(signalGroup == intersection.SignalGroups[1] || signalGroup == intersection.SignalGroups[2])
                                syncObject.crosswalkPressed[1] = false;
                        }
                        else if (signalGroup == intersection.SignalGroups[3] && syncObject.crosswalkPressed[0] == true)
                        {
                            //The crosswalk button has been pushed, show the walk
                            ToggleCrossWalks(signalGroup, true, shortTimeRemaining, timingGroupTimeRemaining);
                        }
                        else if (signalGroup == intersection.SignalGroups[0] && syncObject.crosswalkPressed[1] == true)
                        {
                            //The crosswalk button has been pushed, show the walk
                            ToggleCrossWalks(signalGroup, true, shortTimeRemaining, timingGroupTimeRemaining);
                        }
                    });

                    syncObject.OnTimeToUpdate(intersection);

                    Thread.Sleep(500);
                    timingGroupTimeRemaining -= 500;
                    timeRemaining -= 500;
                    shortTimeRemaining = timingGroupTotalTime - 5000 >= timingGroupTimeRemaining;                        
                }

                currentTimingIndex++;
            }
            
            //ensure all are set to red before proceeding
            //SetAllToRed();
        }

        public void ToggleCrossWalks(SignalGroup signalGroup, bool okToCross, bool shortTimeRemaining, int duration)
        {
            signalGroup.Roadway.CrosswalkOkToWalk = okToCross;
            signalGroup.Roadway.SignalShortRemainingTime = shortTimeRemaining;

            if (okToCross)
                signalGroup.Roadway.CrossWalkRemainingDuration = duration;
            else
                signalGroup.Roadway.CrossWalkRemainingDuration = 0;
      
        }

        /// <summary>
        /// Change the current light color for groups of signals
        /// </summary>
        /// <param name="signalGroups">The signals to act on</param>
        /// <param name="newLightColor">The color to change to</param>
        public void SetSignalGroupsColor(List<SignalGroup> signalGroups, LightColor newLightColor)
        {
            signalGroups.ForEach(signalGroup =>
            {
                SetSignalGroupColor(signalGroup, newLightColor);
            });
            syncObject.OnTimeToUpdate(intersection);
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
            SetSignalGroupsColor(intersection.SignalGroups, LightColor.Red);
        }
    }
}
