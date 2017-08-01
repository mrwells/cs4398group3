using System;
using System.Collections.Generic;
using System.Linq;

//using Newtonsoft.Json;

namespace TrafficControlSystem.Models
{
    public class Intersection
    {
        //[JsonProperty("id")]
        public string Id { get; set; }

       // [JsonProperty("description")]
        public string Description { get; set; }

       // [JsonProperty("signalgroups")]
        public List<SignalGroup> SignalGroups { get; set; }

      //  [JsonProperty("timinggroups")]
        public List<TimingGroup> TimingGroups { get; set; }

        public Intersection()
        {
            SignalGroups = new List<SignalGroup>();
            TimingGroups = new List<TimingGroup>();
        }

        public void OutputCurrentState()
        {
            //Console.Clear();

            foreach (var signalGroup in SignalGroups)
            {
                //Console.WriteLine($"Roadway: {signalGroup.Roadway.Id}, Signal Group: {signalGroup.Id}");

                foreach (var signal in signalGroup.Signals)
                {
                    //Console.Write($"\t{signal.Lane.Direction}-{signal.Lane.Id}: ");
                    SetConsoleColor(signal.CurrentLight);
                    //Console.Write($"{signal.CurrentLight}\n");
                    //Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine();
            }
        }

        public void SetConsoleColor(LightColor lightColor)
        {
            switch (lightColor)
            {
                case LightColor.Green:
                case LightColor.GreenArrow:
                    //Console.ForegroundColor = ConsoleColor.Green;
                    return;
                case LightColor.Yellow:
                case LightColor.YellowArrow:
                    //Console.ForegroundColor = ConsoleColor.Yellow;
                    return;
                case LightColor.Red:
                case LightColor.RedArrow:
                    //Console.ForegroundColor = ConsoleColor.Red;
                    return;
            }
        }
    }
}
