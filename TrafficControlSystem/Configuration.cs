using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using TrafficControlSystem.Models;

namespace TrafficControlSystem
{
    /// <summary>
    /// Configuration Class
    /// </summary>
    /// <remarks>
    /// Configuration Class has 3 attributes:
    /// (List[Roadway]) Roadways - List of Roadways
    /// (List[Intersection] Intersections - List of Intersections
    /// (String) FileName - Name of Configuration File
    /// </remarks>
    public class Configuration
    {
        [JsonProperty("roadways")]
        public List<Roadway> Roadways { get; private set; }
        
        [JsonProperty("intersections")]
        public List<Intersection> Intersections { get; private set; }

        public string FileName { get; set; }

        /// <summary>
        /// Constructor for Configuration
        /// </summary>
        /// <remarks>
        /// Creates a List of Roadways and Intersections 
        /// on instansiation.
        /// </remarks>
        public Configuration()
        {
            Roadways = new List<Roadway>();
            Intersections = new List<Intersection>();
        }

        /// <summary>
        /// Load configuration from file
        /// </summary>
        /// <param name="configurationFileName">Filename of configuration to load</param>
        /// <returns>configuration</returns>
        public static Configuration Load(string configurationFileName)
        {
            var rawConfiguration = System.IO.File.ReadAllText(configurationFileName);
            var configuration = JsonConvert.DeserializeObject<Configuration>(rawConfiguration);
            
            configuration.FileName = configurationFileName;

            configuration.Intersections.ForEach(intersection =>
            {
                //associate timing groups to their related signal groups
                intersection.TimingGroups.ForEach(timinggroup =>
                {
                    timinggroup.SignalGroups = configuration.Intersections.SelectMany(i => i.SignalGroups.Where(signalgroup => timinggroup.SignalGroupIds.Contains(signalgroup.Id))).ToList();
                });

                //associate signal groups to their related roadway and lanes
                intersection.SignalGroups.ForEach(signalgroup =>
                {
                    signalgroup.Roadway = configuration.Roadways.Single(roadway => roadway.Id == signalgroup.RoadwayId);

                    signalgroup.Signals.ForEach(signal =>
                    {                        
                        signal.Lane = signalgroup.Roadway.Lanes.Single(lane => lane.Id == signal.LaneId);
                    });
                });
            });

            return configuration;
        }

        /// <summary>
        /// Output basic configuration information for display
        /// </summary>
        /// <returns>output</returns>
        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine($"Configured from: {FileName}");
            output.AppendLine($"\nRoadways: \n\t{String.Join("\n\t", Roadways.Select(r => r.Name))}");
            output.AppendLine($"\nIntersections: \n\t{String.Join("\n\t", Intersections.Select(r => r.Description))}");
            output.AppendLine();

            return output.ToString();
        }
    }
}
