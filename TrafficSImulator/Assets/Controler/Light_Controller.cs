using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TrafficControlSystem.Models;

public class Light_Controller : MonoBehaviour {

	public bool northright = false;
	public bool northleft = false;

	public bool westright = false;
	public bool westleft = false;

	public void setActiveLights()
	{
		//**************************************
		//Get the data from the config
		string[] north = {};
		string[] west = {};
		string temp = "abc";
		int index = 0;
		//loop through north lanes
		try
		{
			while (temp != null) 
			{
				//get the next lane and put it in to the array
				temp = ConfigManager.getDataRoadway("northlanes_action", index);
				if (temp != null) 
				{
					System.Array.Resize (ref north, north.Length+1);
					north [index] = temp;
				}
				Debug.Log (north [index]);
				index++;
				}
		}
		catch{}
		//reset the variables for the west loop
		temp = "abc";
		index = 0;
		//loop through west lanes
		try{
			while (temp != null) 
			{
				//get the next lane and put it in to the array
				temp = ConfigManager.getDataRoadway("westlanes_action", index);
				if (temp != null)
				{
					System.Array.Resize (ref west, west.Length+1);
					west [index] = temp;
				}

				index++;
			}
		}
		catch{}


		//**************************************
		//check the west lanes, see which are active

		//reset index for the next loop
		index = 0;
		while (index < north.Length) 
		{
			if (north [index] == "left")
				northleft = true;
			else if (north [index] == "right")
				northright = true;

			index++;
		}
		//reset index for the next loop
		index = 0;
		while (index < west.Length) 
		{
			if (west [index] == "left")
				westleft = true;
			else if (west [index] == "right")
				westright = true;

			index++;
		}

	}





}
