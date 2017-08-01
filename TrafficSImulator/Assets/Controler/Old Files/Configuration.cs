using System.IO;
using UnityEngine;
using System.Collections.Generic;

//using System;

///using System.Linq;
//using System.Text;


//using Newtonsoft.Json;
using TrafficControlSystem.Models;

namespace TrafficControlSystem
{



    public class Configuration
    {
		//SO we only have to read the file once
		private GameObject theJsonObject;



    //    [JsonProperty("roadways")]
        public List<Roadway> Roadways { get; private set; }
        
     //   [JsonProperty("intersections")]
        public List<Intersection> Intersections { get; private set; }

        public string FileName { get; set; }

        public Configuration()
        {
			//theJsonObject = Load;

			if (theJsonObject == null) 
			{
				//We have a null object.  We did not load anything from the file
			}

            Roadways = new List<Roadway>();
            Intersections = new List<Intersection>();
        }



		//*****************************************************************
		//*****************************************************************
		//*****************************************************************

		//Loads the config file into a game object so it can be used
		//    by other parts of the program
		public static GameObject Load(string configurationFileName)
		{
			if (File.Exists (configurationFileName)) {
				//Read the file into a string
				string dataAsJson = File.ReadAllText(configurationFileName);

				//change the string into a game object
				GameObject configData = JsonUtility.FromJson<GameObject>(dataAsJson);

				return configData;
			}

			return null;
		}

		//*****************************************************************
		//*****************************************************************
		//*****************************************************************

		public string getValue(string key)
		{
			return "";// theJsonObject.GetString(key);
		}


       // public static Configuration Load(string configurationFileName)
      //  {
			
		//	var configuration = (Configuration)System.IO.File.ReadAllText(configurationFileName);
            /*
			//var configuration = JsonConvert.DeserializeObject<Configuration>(rawConfiguration);
            
            //configuration.FileName = configurationFileName;

            //configuration.Intersections.ForEach(intersection =>
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

			*/
    //       return configuration;
     //   }

        public override string ToString()
        {
           // var output = new StringBuilder();

//            output.AppendLine($"Configured from: {FileName}");
  //          output.AppendLine($"\nRoadways: \n\t{String.Join("\n\t", Roadways.Select(r => r.Name))}");
    //        output.AppendLine($"\nIntersections: \n\t{String.Join("\n\t", Intersections.Select(r => r.Description))}");
      //      output.AppendLine();

           // return output.ToString();

			return null;
        }
    }
}
