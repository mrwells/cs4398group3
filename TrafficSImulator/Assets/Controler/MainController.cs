using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using TrafficControlSystem.Models;

public class MainController : MonoBehaviour {

	//Show the road names
	public Text northText;
	public Text westText;

	//Show how much time is left on the timer
	public Text Timer;

	//The lenght of time to stay green or yellow
	public float GreenTime = 3.0f;
	public float YellowTime = 2.0f;

	//the counter that keeps track of how much longer to keep a light that color
	private double timer_countdown;

	//What timer we are currently using
	private string timerType = "green";


	// Use this for initialization
	void Start () {

		//Read the Config file
		//*************************
		// THIS MUST BE DONE BEFORE ANYTHING ELSE
		//*************************
		ConfigManager.readConfigFile("testConfig.txt");

		//set up the text fields, and populate those which need populating
		setText();






		//Read the Config File
		
	}
	
	// Update is called once per frame
	void Update () {
		//remove the amount of time since last update
		timer_countdown -= Time.deltaTime;


		if (timer_countdown <= 0 && timerType == "green") {
			timer_countdown = YellowTime;
			timerType = "yellow";
			//changeLightColor ();
		} else if (timer_countdown <= 0 && timerType == "yellow") {
			timer_countdown = GreenTime;
			timerType = "green";
			//changeLightColor ();
		}


		//show remaining time on the screen
		Timer.GetComponent<Text>().text = "Time Remaining: " + timer_countdown.ToString("F1");





		
	}

	//sets initial values of text that dont change during run
	private void setText()
	{
		//Find the text field where we will store our timer
		Timer = GetComponent<Text>();
		Timer = GameObject.Find ("Timer").GetComponent<Text>();

		//Find the text field for the North Road Name
		northText = GetComponent<Text>();
		northText = GameObject.Find ("NorthRoadName").GetComponent<Text>();

		//Find the text field for the West Road Name
		westText = GetComponent<Text>();
		westText = GameObject.Find ("WestRoadName").GetComponent<Text>();

		northText.GetComponent<Text>().text = ConfigManager.getDataRoadway("northname");
		westText.GetComponent<Text>().text = ConfigManager.getDataRoadway("westname");
	}
}
