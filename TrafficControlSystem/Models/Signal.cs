using System.Collections.Generic;

using Newtonsoft.Json;

namespace TrafficControlSystem.Models
{
    public class Signal
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lane")]
        public Lane Lane { get; set; }

        [JsonProperty("lights")]
        public List<string> Lights { get; set; }

        public Signal()
        {
            Lights = new List<string>();
        }
    }
}
