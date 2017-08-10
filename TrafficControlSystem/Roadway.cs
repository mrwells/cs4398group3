
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TrafficControlSystem
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
        /// <summary>
        /// A string property that contains the roadway ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// A string property that contains the roadway name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// A Lane property that contains a list of the lanes for the roadway.
        /// </summary>
        [JsonProperty("lanes")]
        public List<Lane> Lanes { get; set; }

        /// <summary>
        ///  A boolean property that specifies if the crosswalk is OK to use for the roadway.
        /// </summary>
        public bool CrosswalkOkToWalk { get; set; }

        /// <summary>
        ///  A boolean property that specifies if the short remaining time is used for the roadway.
        /// </summary>
        public bool SignalShortRemainingTime { get; set; }

        /// <summary>
        /// A integer property that specifies the remaining crosswalk duration.
        /// </summary>
        public int CrossWalkRemainingDuration { get; set; }

        /// <summary>
        /// Constructor for Roadway
        /// </summary>
        /// <remarks>
        /// Creates new List of Lanes on instansiation.</remarks>
        public Roadway()
        {
            Lanes = new List<Lane>();
            CrosswalkOkToWalk = false;
            SignalShortRemainingTime = false;
        }
    }
}
