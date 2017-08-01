using System.Collections.Generic;
//using Newtonsoft.Json;

using TrafficControlSystem.Models;

namespace TrafficControlSystem.Models
{
	[System.Serializable]
    public class Signal
    {
        public string id { get; set; }
        public string laneId { get; set; }
        public List<LightColor> lights { get; set; }

        public Signal()
        {
            
        }
    }
}
