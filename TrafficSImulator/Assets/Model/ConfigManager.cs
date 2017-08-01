using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace TrafficControlSystem.Models
{
	public class ConfigManager : MonoBehaviour {

		//we will read the data once and store it here so
		//   we are not constantly accessing the file
		private static ConfigData theConfigData = null;
		//private static TestConfigur theConfigData = null;
		private static string currentConfigFile = null;





		//private static TestConfigur loadData(string configFileName)
		private static ConfigData loadData(string configFileName)
		{
			string filePath = "C:\\Users\\owner\\Documents\\GitHub\\cs4398group3\\TrafficSImulator\\Assets\\Model\\Config\\" + configFileName;


			//Read the file into one massive string
			string dataAsJson = File.ReadAllText(filePath);

			//Parse the massive string into an object
			ConfigData theData = JsonUtility.FromJson<ConfigData>(dataAsJson);
			//TestConfigur theData = JsonUtility.FromJson<TestConfigur>(dataAsJson);

			//in case we want to change which file we are using
			currentConfigFile = configFileName;

			return theData;
		}

		public static void readConfigFile(string configFile = "defaultConfig.txt")
		{
			if (currentConfigFile == null || currentConfigFile != configFile) 
			{
				theConfigData = loadData (configFile);
				return;
			}
			else
				return;
		
		}

		public static string getDataRoadway(string key, int index = 0)
		{
			string response = "Hi";
			if (key == "northid") {
				response = theConfigData.roadways.northid;
				Debug.Log (theConfigData.roadways.northid);
			} else if (key == "northname") {
				response = theConfigData.roadways.northname;
			}
			return response;
		}

		public string getDataIntersection(string key)
		{
			if (key == "") {
			} else if (key == "") {
			}
			return null;// theConfigData.
		}












		// Use this for initialization
		void Start () {
		
		}
	
		// Update is called once per frame
		void Update () {
		
		}





	}
}
