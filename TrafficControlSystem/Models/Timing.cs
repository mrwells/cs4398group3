
using Newtonsoft.Json;

namespace TrafficControlSystem.Models
{
    public struct Timing
    {        
        [JsonProperty("light")]
        public LightColor Light;

        [JsonProperty("order")]
        public int Order;

        [JsonProperty("duration")]
        public int Duration;
    }
}
