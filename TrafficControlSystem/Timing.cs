
using Newtonsoft.Json;

namespace TrafficControlSystem
{
    /// <summary>
    /// Timing Structure
    /// </summary>
    /// <remarks>
    /// Timing Structure has 3 attributes:\n
    /// (LightColor) Light\n
    /// (int) Order\n
    /// (int) Duration
    /// </remarks>
    public struct Timing
    {
        /// <summary>
        /// A LightColor property that contains the timing light color.
        /// </summary>
        [JsonProperty("light")]
        public LightColor Light;

        /// <summary>
        /// A integer property that contains the timing order.
        /// </summary>
        [JsonProperty("order")]
        public int Order;

        /// <summary>
        /// A integer property that contains the timing duration in seconds.
        /// </summary>
        [JsonProperty("duration")]
        public int Duration;
    }
}
