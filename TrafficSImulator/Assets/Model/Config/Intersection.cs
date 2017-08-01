using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficControlSystem.Models
{
[System.Serializable]
public class Intersection 
	{
	public string id { get; set; }
	public string description { get; set; }
	public SignalGroup[] SignalGroups { get; set; }
	public TimingGroup[] TimingGroups { get; set; }

	public Intersection()
	{
		//SignalGroups = new List<SignalGroup>();
		//TimingGroups = new List<TimingGroup>();
	}

	}
}