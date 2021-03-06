﻿using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace TrafficControlSystem
{
    /// <summary>
    /// Intersection Class
    /// </summary>
    /// <remarks>
    /// Intersection Class has 4 attributes: 
    /// (String) Id
    /// (String) Description
    /// (List[SignalGroup]) SignalGroups - List of SignalGroups
    /// (List[TimingGroups]) TimingGroups - List of TimingGroups
    /// </remarks>
    public class Intersection
    {
        /// <summary>
        /// A string property that contains the description of the intersection.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// A SignalGroup property that contains a list of the signal groups of the intersection.
        /// </summary>
        [JsonProperty("signalgroups")]
        public List<SignalGroup> SignalGroups { get; set; }

        /// <summary>
        /// A TimingGroup property that contains a list of the timing groups of the intersection.
        /// </summary>
        [JsonProperty("timinggroups")]
        public List<TimingGroup> TimingGroups { get; set; }

        /// <summary>
        /// Constructor for Intersection
        /// </summary>
        /// <remarks>
        /// Creates SignalGroups and TimingGroups lists on instansiation
        /// </remarks>
        public Intersection()
        {
            SignalGroups = new List<SignalGroup>();
            TimingGroups = new List<TimingGroup>();
        }

        /// <summary>
        /// Display current state of console.
        /// </summary>
        public void OutputCurrentState()
        {
            Console.Clear();

            foreach (var signalGroup in SignalGroups)
            {
                Console.WriteLine($"Roadway: {signalGroup.Roadway.Id}, Signal Group: {signalGroup.Id}");

                foreach (var signal in signalGroup.Signals)
                {
                    Console.Write($"\t{signal.Lane.Direction}-{signal.Lane.Id}: ");
                    SetConsoleColor(signal.CurrentLight);
                    Console.Write($"{signal.CurrentLight}\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// SetConsoleColor changes the color of the output to the screen
        /// based on the parameter passed.
        /// </summary>
        /// <param name="lightColor">A LightColor enum that is used to set the text color in the console.</param>
        public void SetConsoleColor(LightColor lightColor)
        {
            switch (lightColor)
            {
                case LightColor.Green:
                case LightColor.GreenArrow:
                    Console.ForegroundColor = ConsoleColor.Green;
                    return;
                case LightColor.Yellow:
                case LightColor.YellowArrow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    return;
                case LightColor.Red:
                case LightColor.RedArrow:
                    Console.ForegroundColor = ConsoleColor.Red;
                    return;
            }
        }
    }
}
