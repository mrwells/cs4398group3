using System.Collections.Generic;

//using Newtonsoft.Json;

namespace TrafficControlSystem.Models
{
	[System.Serializable]
    public class TimingGroup
    {
        public string id { get; set; }
        public List<string> signalgroupids { get; set; }
        public List<Timing> signaltiming { get; set; }


        public TimingGroup()
        {
            
        }
    }
}
