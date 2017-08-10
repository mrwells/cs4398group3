﻿
using Newtonsoft.Json;

namespace TrafficControlSystem
{
    /// <summary>
    /// Lane Class
    /// </summary>
    /// <remarks>
    /// Lane Class has 3 attributes:\n
    /// (String) Id\n
    /// (String) Description\n
    /// (String) Direction\n
    /// </remarks>
    public class Lane
    {
        /// <summary>
        /// A string property that contains the lane ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// A string property that contains the lane direction.
        /// </summary>
        [JsonProperty("direction")]
        public string Direction { get; set; }
    }
}
