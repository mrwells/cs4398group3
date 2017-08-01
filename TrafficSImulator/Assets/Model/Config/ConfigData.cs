using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficControlSystem.Models
{
	[System.Serializable]
	public class ConfigData 
	{
		public string id;
		public Roadway roadways;
		public Intersection intersections;

	}
}