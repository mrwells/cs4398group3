using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

	//Holds the game object that will show what color the light is
	public GameObject northRight;
	public GameObject northStraight;
	public GameObject northLeft;

	public GameObject southRight;
	public GameObject southStraight;
	public GameObject southLeft;

	public GameObject eastRight;
	public GameObject eastStraight;
	public GameObject eastLeft;

	public GameObject westRight;
	public GameObject westStraight;
	public GameObject westLeft;


	// Use this for initialization
	void Start () {
		northRight = GameObject.Find ("northRight");
		northStraight = GameObject.Find ("northStraight");
		northLeft = GameObject.Find ("northLeft");

		southRight = GameObject.Find ("southRight");
		southStraight = GameObject.Find ("southStraight");
		southLeft = GameObject.Find ("southLeft");

		eastRight = GameObject.Find ("eastRight");
		eastStraight = GameObject.Find ("eastStraight");
		eastLeft = GameObject.Find ("eastLeft");

		westRight = GameObject.Find ("westRight");
		westStraight = GameObject.Find ("westStraight");
		westLeft = GameObject.Find ("westLeft");

		startRed ();


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setColor( GameObject whichLight, Color newColor)
	{
		whichLight.gameObject.GetComponent<Renderer> ().material.color = newColor;
	}

	//public void setColor( int whichLight, Color newColor)
	//{
	//	GameObject theLight = westRight;
	//	theLight.gameObject.GetComponent<Renderer> ().material.color = newColor;
	//}

	private void startRed()
	{
		setColor (northRight, Color.red);
		setColor (northStraight, Color.red);
		setColor (northLeft, Color.red);

		setColor (southRight, Color.red);
		setColor (southStraight, Color.red);
		setColor (southLeft, Color.red);

		setColor (eastRight, Color.red);
		setColor (eastStraight, Color.red);
		setColor (eastLeft, Color.red);

		setColor (westRight, Color.red);
		setColor (westStraight, Color.red);
		setColor (westLeft, Color.red);
	}
}
