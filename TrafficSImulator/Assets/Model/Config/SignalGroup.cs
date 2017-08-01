
using System.Collections.Generic;
//using Newtonsoft.Json;


namespace TrafficControlSystem.Models
{
	[System.Serializable]
    public class SignalGroup
    {
		public string id;
		public string roadwayId;
		public Signal[] signals;


		public SignalGroup()
        {
            //Signals = new List<Signal>();
        }
    }
}
