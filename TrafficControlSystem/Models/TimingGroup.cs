using System.Collections.Generic;

using Newtonsoft.Json;

namespace TrafficControlSystem.Models
{
    /// <summary>
    /// TimingGroup Class
    /// </summary>
    /// <remarks>
    /// TimingGroup Class has 4 attributes:
    /// (String) Id - TimingGroup ID
    /// (List[String]) SignalGroupsIds - List of Strings
    /// (List[SignalGroup]) SignalGroups - List of SignalGroups 
    /// (List[Timing]) Timings - List of Timings
    /// (</remarks>
    public class TimingGroup
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("signalgroupids")]
        public List<string> SignalGroupIds { get; set; }
        
        public List<SignalGroup> SignalGroups { get; set; }

        [JsonProperty("signaltiming")]
        public List<Timing> Timings { get; set; }

        /// <summary>
        /// Constructor for TimingGroup
        /// </summary>
        /// <remarks>
        /// Creates a List of SignalGroups and Timings on instansiation.</remarks>
        public TimingGroup()
        {
            SignalGroups = new List<SignalGroup>();
            Timings = new List<Timing>();
        }
    }
}
