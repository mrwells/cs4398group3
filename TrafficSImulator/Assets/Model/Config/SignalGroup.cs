
using System.Collections.Generic;
//using Newtonsoft.Json;


namespace TrafficControlSystem.Models
{
	[System.Serializable]
    public class SignalGroup
    {
        public string id { get; set; }
        public string roadwayId { get; set; }
        public List<Signal> signals { get; set; }


		public SignalGroup()
        {
            //Signals = new List<Signal>();
        }
    }
}
