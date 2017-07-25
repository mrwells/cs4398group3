using System.Collections.Generic;

using Newtonsoft.Json;

namespace TrafficControlSystem.Models
{
    public class Intersection
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("signalgroups")]
        public List<SignalGroup> SignalGroups { get; set; }

        [JsonProperty("timinggroups")]
        public List<TimingGroup> TimingGroups { get; set; }

        public Intersection()
        {
            SignalGroups = new List<SignalGroup>();
            TimingGroups = new List<TimingGroup>();
        }
    }
}
