using System.Collections.Generic;

using Newtonsoft.Json;

namespace TrafficControlSystem.Models
{
    public class TimingGroup
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("signalgroupids")]
        public List<string> SignalGroupIds { get; set; }
        
        public List<SignalGroup> SignalGroups { get; set; }

        [JsonProperty("signaltiming")]
        public List<Timing> Timings { get; set; }


        public TimingGroup()
        {
            SignalGroups = new List<SignalGroup>();
            Timings = new List<Timing>();
        }
    }
}
