using System.Collections;
using System.Collections.Generic;
//using Newtonsoft.Json;

namespace TrafficControlSystem.Models
{
	[System.Serializable]
    public class Roadway
    {
		public string northid;
		public string northname;
		public Lane[] northlanes;

		public string westid;
		public string westname;
		public Lane[] westlanes;


		 
        public Roadway()
        {
            //Lanes = new List<Lane>();
        }
    }
}
