
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TrafficControlSystem.Models
{
    public class SignalGroup
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("roadwayid")]
        public string RoadwayId { get; set; }
        
        public Roadway Roadway { get; set; }

        [JsonProperty("signals")]
        public List<Signal> Signals { get; set; }

        public SignalGroup()
        {
            Signals = new List<Signal>();
        }
    }
}
