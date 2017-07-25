
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
    }
}
