using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Matches : MonoBehaviour {

	public Sprite ThreeLeft;
	public Sprite TwoLeft;
	public Sprite OneLeft;

	Image uiImage;

	// Use this for initialization
	void Start () {
		uiImage = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void setMatchesLeft(int iVal)
	{
		if (iVal == 3) 
		{
			uiImage.sprite = ThreeLeft;
			uiImage.enabled = true;
		} 
		else if (iVal == 2) 
		{
			uiImage.sprite = TwoLeft;
			uiImage.enabled = true;
		} 
		else if (iVal == 1) 
		{
			uiImage.sprite = ThreeLeft;
			uiImage.enabled = true;
		} 
		else if (iVal == 0) 
		{
			uiImage.enabled = false;
		}
	}
}
