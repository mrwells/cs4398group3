
using Newtonsoft.Json;

namespace TrafficControlSystem.Models
{
    public class Lane
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }
    }
}
