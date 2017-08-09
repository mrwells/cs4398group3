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
        /// <summary>
        /// A string property that contains the signal ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// A string property that contains the signal lane ID.
        /// </summary>
        [JsonProperty("laneid")]
        public string LaneId { get; set; }

        /// <summary>
        /// A Lane property that contains the signal lane.
        /// </summary>
        public Lane Lane { get; set; }

        /// <summary>
        /// A LightColor property that contains a list of light colors for the signal.
        /// </summary>
        [JsonProperty("lights")]
        public List<LightColor> Lights { get; set; }

        /// <summary>
        /// A LightColor property that contains the current light color of the signal.
        /// </summary>
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
