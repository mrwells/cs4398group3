
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TrafficControlSystem
{
    /// <summary>
    /// Roadway Class
    /// </summary>
    /// <remarks>
    /// Roadway Class has 3 attributes:/n
    /// (String) Id - Roadway ID/n
    /// (String) Name - Roadway Name/n
    /// (List[Lanes] Lanes - List of Lanes that are part of Roadway
    /// </remarks>
    public class Roadway
    {
        /// <summary>
        /// A string property that contains the roadway ID.
        /// </summary>
        /// <remarks>
        /// Creates getters and setters for Id.
        /// </remarks>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// A string property that contains the roadway name.
        /// </summary>
        /// <remarks>
        /// Creates getter and setters for Name.
        /// </remarks>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// A Lane property that contains a list of the lanes for the roadway.
        /// </summary>
        /// <remarks>
        /// Creates getters and setters for Lanes.</remarks>
        [JsonProperty("lanes")]
        public List<Lane> Lanes { get; set; }
        
        /// <summary>
        /// Determines if Crosswalk is safe to cross based on boolean value returned.
        /// </summary>
        /// <remarks>
        /// True - Safe to Cross./n
        /// False - Unsafe to Cross.
        /// </remarks>
        public bool CrosswalkOkToWalk { get; set; }

        /// <summary>
        /// Boolean value that is true if there is a short remaining time on Crosswalk.\n
        /// Otherwise is False.
        /// </summary>
        public bool SignalShortRemainingTime { get; set; }

        /// <summary>
        /// Integer that tells how much time is left to cross the street.
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
