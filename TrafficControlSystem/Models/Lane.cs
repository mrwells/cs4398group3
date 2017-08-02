
using Newtonsoft.Json;

namespace TrafficControlSystem.Models
{
    /// <summary>
    /// Lane Class
    /// </summary>
    /// <remarks>
    /// Lane Class has 3 attributes:
    /// (String) Id
    /// (String) Description
    /// (String) Direction
    /// </remarks>
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
