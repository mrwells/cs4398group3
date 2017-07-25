
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TrafficControlSystem.Models
{
    public class Roadway
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lanes")]
        public List<Lane> Lanes { get; set; }

        public Roadway()
        {
            Lanes = new List<Lane>();
        }
    }
}
