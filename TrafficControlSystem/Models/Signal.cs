using System.Collections.Generic;
using Newtonsoft.Json;

using TrafficControlSystem.Models;

namespace TrafficControlSystem.Models
{
    /// <summary>
    /// Signal Class
    /// </summary>
    /// <remarks>
    /// Signal Class has 5 attributes:
    /// (String) Id - Signal ID
    /// (String) LaneId - Lane ID
    /// (Lane) Lane - A Lane
    /// (List[LightColor]) Lights - List of LightColors
    /// (LightColor) CurrentLight - The Current Light</remarks>
    public class Signal
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("laneid")]
        public string LaneId { get; set; }
        
        public Lane Lane { get; set; }

        [JsonProperty("lights")]
        public List<LightColor> Lights { get; set; }

        public LightColor CurrentLight { get; set; }

        /// <summary>
        /// Constructor for Signal
        /// </summary>
        /// <remarks>
        /// Creates a List of Lights and sets light color to Red.
        /// </remarks>
        public Signal()
        {
            Lights = new List<LightColor>();
            CurrentLight = LightColor.Red;
        }
    }
}
