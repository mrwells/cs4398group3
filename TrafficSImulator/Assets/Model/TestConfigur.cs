using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TrafficControlSystem.Models;

[System.Serializable]
public class TestConfigur  {

	public string id;
	public string name;
	public Roadway roadways;
}


/*
 * {
	"id" :"universityblvd",
	"name" : "University Blvd",
	"roadways" : 
		{   
			"id" :"neasldkjfladsk",
			"name" : "NEsted",
			"lanes" : 
				{
					"id": "1",
					"description" : "Inner lane",
					"direction" : "East"				
				}

			}
		
				
}
*/