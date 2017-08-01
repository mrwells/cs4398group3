using System.Collections.Generic;
//using Newtonsoft.Json;

using TrafficControlSystem.Models;

namespace TrafficControlSystem.Models
{
    public class Signal
    {
        //[JsonProperty("id")]
        public string Id { get; set; }

        //[JsonProperty("laneid")]
        public string LaneId { get; set; }
        
        public Lane Lane { get; set; }

        //[JsonProperty("lights")]
        public List<LightColor> Lights { get; set; }

        public LightColor CurrentLight { get; set; }

        public Signal()
        {
            Lights = new List<LightColor>();
            CurrentLight = LightColor.Red;
        }
    }
}
