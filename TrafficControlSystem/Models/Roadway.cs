
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TrafficControlSystem.Models
{
    /// <summary>
    /// Roadway Class
    /// </summary>
    /// <remarks>
    /// Roadway Class has 3 attributes:
    /// (String) Id - Roadway ID
    /// (String) Name - Roadway Name
    /// (List[Lanes] Lanes - List of Lanes that are part of Roadway
    /// </remarks>
    public class Roadway
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lanes")]
        public List<Lane> Lanes { get; set; }

        /// <summary>
        /// Constructor for Roadway
        /// </summary>
        /// <remarks>
        /// Creates new List of Lanes on instansiation.</remarks>
        public Roadway()
        {
            Lanes = new List<Lane>();
        }
    }
}
