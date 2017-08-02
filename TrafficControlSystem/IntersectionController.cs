using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TrafficControlSystem.Models;

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
                SetSignalGroupsColor(timingGroup.SignalGroups, timing.Light);
                intersection.OutputCurrentState();
                System.Threading.Thread.Sleep(timing.Duration * 1000);
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
        public void SetSignalGroupsColor(List<SignalGroup> signalGroups, LightColor newLightColor)
        {
            signalGroups.ForEach(signalGroup =>
            {
                SetSignalGroupColor(signalGroup, newLightColor);
            });
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
