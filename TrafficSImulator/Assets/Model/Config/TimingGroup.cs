using System.Collections.Generic;

//using Newtonsoft.Json;

namespace TrafficControlSystem.Models
{
	[System.Serializable]
    public class TimingGroup
    {
		public string id;
        //public List<string> signalgroupids { get; set; }
		public Timing[] signaltiming;


        public TimingGroup()
        {
            
        }
    }
}
