
//using Newtonsoft.Json;

namespace TrafficControlSystem.Models
{
	[System.Serializable]
    public struct Timing
    {
		public int order;
        public LightColor light;
        public int duration;
    }
}
