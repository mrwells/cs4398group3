using System.Collections.Generic;

using Newtonsoft.Json;

namespace TrafficControlSystem
{
    /// <summary>
    /// TimingGroup Class
    /// </summary>
    /// <remarks>
    /// TimingGroup Class has 4 attributes:\n
    /// (String) Id - TimingGroup ID\n
    /// (List[String]) SignalGroupsIds - List of Strings\n
    /// (List[SignalGroup]) SignalGroups - List of SignalGroups\n 
    /// (List[Timing]) Timings - List of Timings
    /// (</remarks>
    public class TimingGroup
    {
        /// <summary>
        /// A string property that contains the timing group id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// A string property that contains a list of the signal group ids in the timing group.
        /// </summary>
        [JsonProperty("signalgroupids")]
        public List<string> SignalGroupIds { get; set; }

        /// <summary>
        /// A SignalGroup property that contains a list of the signal groups in the timing group.
        /// </summary>
        public List<SignalGroup> SignalGroups { get; set; }

        /// <summary>
        /// A Timing property that contains a list of the timings in the timing group.
        /// </summary>
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
