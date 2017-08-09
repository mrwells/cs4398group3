
using Newtonsoft.Json;

namespace TrafficControlSystem.Models
{
    /// <summary>
    /// Timing Structure
    /// </summary>
    /// <remarks>
    /// Timing Structure has 3 attributes:
    /// (LightColor) Light
    /// (int) Order
    /// (int) Duration
    /// </remarks>
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
