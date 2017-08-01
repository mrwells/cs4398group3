using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TrafficControlSystem.Models;

public class Light_Controller : MonoBehaviour {

	//Holds the game object that will show what color the light is
	//public GameObject northLigth;
	//public GameObject southLigth;
	//public GameObject eastLigth;
	//public GameObject westLigth;
	public ChangeColor colorChanger;

	//Show how much time is left on the timer
	public Text Timer;

	//Print Debut Text
	public Text debugText;

	//The lenght of time to stay green or yellow
	public float GreenTime = 3.0f;
	public float YellowTime = 2.0f;

	//the counter that keeps track of how much longer to keep a light that color
	private double timer_countdown;

	//What timer we are currently using
	private string timerType = "green";

	//current light showing
	private string whichLight = "north";



	// Use this for initialization
	void Start () {

		//Read the Config file
		ConfigManager.readConfigFile(""); 

		//Find the objects for each of the lights
		//northLigth = GameObject.Find ("North Light");
		//southLigth = GameObject.Find ("South Light");
		//eastLigth = GameObject.Find ("East Light");
		//westLigth = GameObject.Find ("West Light");


		//Set the lights to their starting colors
		//northLigth.gameObject.GetComponent<Renderer> ().material.color = Color.green;
		//southLigth.gameObject.GetComponent<Renderer> ().material.color = Color.red;
		//eastLigth.gameObject.GetComponent<Renderer> ().material.color = Color.red;
		//westLigth.gameObject.GetComponent<Renderer> ().material.color = Color.red;

		//Find the text field where we will store our timer
		Timer = GetComponent<Text>();
		Timer = GameObject.Find ("Timer").GetComponent<Text>();

		debugText = GetComponent<Text>();
		debugText = GameObject.Find ("DebugText").GetComponent<Text>();

		string debutstring = "";
		debutstring += ConfigManager.getDataRoadway ("id").ToString();

		Debug.Log ("" + debutstring);

		debugText.GetComponent<Text>().text = debutstring;

		
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

		Timer.GetComponent<Text>().text = "Time Remaining: " + timer_countdown.ToString("F1");
	}

	/*
	void changeLightColor()
	{
		if (timerType == "green") {
			//we already changed the color of timerType, so red to the current light, green to the next, then set whichLLight to next light
			if (whichLight == "north") {
				northLigth.gameObject.GetComponent<Renderer> ().material.color = Color.red;
				eastLigth.gameObject.GetComponent<Renderer> ().material.color = Color.green;
				whichLight = "east";
			}else if (whichLight == "east") {
				eastLigth.gameObject.GetComponent<Renderer> ().material.color = Color.red;
				southLigth.gameObject.GetComponent<Renderer> ().material.color = Color.green;
				whichLight = "south";
			}else if (whichLight == "south") {
				southLigth.gameObject.GetComponent<Renderer> ().material.color = Color.red;
				westLigth.gameObject.GetComponent<Renderer> ().material.color = Color.green;
				whichLight = "west";
			}else if (whichLight == "west") {
				westLigth.gameObject.GetComponent<Renderer> ().material.color = Color.red;
				northLigth.gameObject.GetComponent<Renderer> ().material.color = Color.green;
				whichLight = "north";
			}
		} else {
			if (whichLight == "north") {
				northLigth.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			}else if (whichLight == "south") {
				southLigth.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			}else if (whichLight == "east") {
				eastLigth.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			}else if (whichLight == "west") {
				westLigth.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			}
		}
	}
	*/
}
