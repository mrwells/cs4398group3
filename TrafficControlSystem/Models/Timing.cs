
using Newtonsoft.Json;

namespace TrafficControlSystem.Models
{
    public struct Timing
    {
        [JsonProperty("light")]
        public string Light;

        [JsonProperty("order")]
        public int Order;

        [JsonProperty("duration")]
        public int Duration;
    }
}
