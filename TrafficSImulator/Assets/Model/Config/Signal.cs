using System.Collections.Generic;
//using Newtonsoft.Json;

using TrafficControlSystem.Models;

namespace TrafficControlSystem.Models
{
	[System.Serializable]
    public class Signal
    {
		public string id;
		public string laneid;
		public LightColor[] lights;

        public Signal()
        {
            
        }
    }
}
