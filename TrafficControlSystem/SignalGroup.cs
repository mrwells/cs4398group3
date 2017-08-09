
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TrafficControlSystem
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
        /// <summary>
        /// A string property that contains the signal group id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// A string property that contains the signal group roadway id.
        /// </summary>
        [JsonProperty("roadwayid")]
        public string RoadwayId { get; set; }

        /// <summary>
        /// A Roadway property that contains the roadway for the signal group.
        /// </summary>
        public Roadway Roadway { get; set; }

        /// <summary>
        /// A Signal property that contains a list of the signals in the signal group.
        /// </summary>
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
