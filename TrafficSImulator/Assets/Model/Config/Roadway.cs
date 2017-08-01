using System.Collections;
using System.Collections.Generic;
//using Newtonsoft.Json;

namespace TrafficControlSystem.Models
{
	[System.Serializable]
    public class Roadway
    {
		//public string id;
        public string id { get; set; }
        public string name { get; set; }
        public List<Lane> lanes { get; set; }


        public Roadway()
        {
            //Lanes = new List<Lane>();
        }
    }
}
