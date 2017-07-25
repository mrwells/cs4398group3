using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using TrafficControlSystem.Models;

namespace TrafficControlSystem
{
    public class Configuration
    {
        [JsonProperty("roadways")]
        public List<Roadway> Roadways { get; private set; }
        
        [JsonProperty("intersections")]
        public List<Intersection> Intersections { get; private set; }

        public Configuration()
        {
            Roadways = new List<Roadway>();
            Intersections = new List<Intersection>();
        }

        public static Configuration Load(string configurationFileName)
        {
            var rawConfiguration = System.IO.File.ReadAllText(configurationFileName);

            var configuration = JsonConvert.DeserializeObject<Configuration>(rawConfiguration);
            
            configuration.Intersections.ForEach(intersection =>
            {
                intersection.SignalGroups.ForEach(signalgroup =>
                {
                    signalgroup.Roadway = configuration.Roadways.Single(roadway => roadway.Id == signalgroup.RoadwayId);
                });

                intersection.TimingGroups.ForEach(timinggroup =>
                {
                    timinggroup.SignalGroups = configuration.Intersections.SelectMany(i => i.SignalGroups.Where(signalgroup => timinggroup.SignalGroupIds.Contains(signalgroup.Id))).ToList();
                });
            });

            return configuration;
        }
    }
}
