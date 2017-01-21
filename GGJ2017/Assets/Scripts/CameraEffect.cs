using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffect : MonoBehaviour {


	public Animator cameraanimator;
//	public GameObject Enemy;
	// Use this for initialization
	void Start () {
		cameraanimator.SetFloat("speed", 0);


	}
	
	// Update is called once per frame
	void OnTriggerEnter( Collider theCollision )
	{
		
		if (theCollision.gameObject.tag == "Enemy")
			// By using {}, the condition apply to that entire scope, instead of the next line.
		{ 
			print("ca pue");
			cameraanimator.SetBool("Enter", true);
		}
	}
	void OnTriggerExit( Collider theCollision )
	{

		if (theCollision.gameObject.tag == "Enemy")
			// By using {}, the condition apply to that entire scope, instead of the next line.
		{ 
			print("ouf");
			cameraanimator.SetBool("Enter", false);
		}
	}
}
