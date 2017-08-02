
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TrafficControlSystem.Models
{
    /// <summary>
    /// SignalGroup Class 
    /// </summary>
    /// <remarks>
    /// SignalGroup Class has 4 attributes:
    /// (String) Id - SignalGroup ID
    /// (String) RoadwayId - Roadway ID
    /// (Roadway) Roadway - A Roadway
    /// (List[Signals]) Signals - List of Signals
    /// </remarks>
    public class SignalGroup
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("roadwayid")]
        public string RoadwayId { get; set; }
        
        public Roadway Roadway { get; set; }

        [JsonProperty("signals")]
        public List<Signal> Signals { get; set; }

        /// <summary>
        /// Constructor for SignalGroup
        /// </summary>
        /// <remarks>
        /// Creates a new List of Signals on instantiation.
        /// </remarks>
        public SignalGroup()
        {
            Signals = new List<Signal>();
        }
    }
}
