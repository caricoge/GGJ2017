using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Matches : MonoBehaviour {

	public Image MatchOne;
	public Image MatchTwo;
	public Image MatchThree;

	// Use this for initialization
	void Start () {
		//uiImage = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void setMatchesLeft(int iVal)
	{
		if (iVal == 3) 
		{
			MatchOne.enabled = true;
			MatchTwo.enabled = true;
			MatchThree.enabled = true;
		} 
		else if (iVal == 2) 
		{
			MatchOne.enabled = false;
			MatchTwo.enabled = true;
			MatchThree.enabled = true;
		} 
		else if (iVal == 1) 
		{
			MatchOne.enabled = false;
			MatchTwo.enabled = false;
			MatchThree.enabled = true;
		} 
		else if (iVal == 0) 
		{
			MatchOne.enabled = false;
			MatchTwo.enabled = false;
			MatchThree.enabled = false;
		}
	}
}
