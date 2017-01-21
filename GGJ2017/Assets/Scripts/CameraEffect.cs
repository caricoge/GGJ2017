using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffect : MonoBehaviour {


	public Animator cameraanimator;
	public Animator playeranimator;

//	public GameObject Enemy;
	// Use this for initialization
	void Start () {
		cameraanimator.SetFloat("speed", 0);


	}
	void Update(){

		if(Input.GetButton("Fire2")){
			playeranimator.SetBool("Fire2",true);

		}
		else {

			playeranimator.SetBool("Fire2",false);

		}
		if(Input.GetButtonDown("Fire1")){
			playeranimator.SetBool("Fire1",true);
		}
		else {

			playeranimator.SetBool("Fire1",false);

		}
		if(Input.GetKeyDown("e")){
			playeranimator.SetBool("Grab",true);
		}
		else {

			playeranimator.SetBool("Grab",false);

		}

	}
	
	// Update is called once per frame
	void OnTriggerEnter( Collider theCollision )
	{
		
		if (theCollision.gameObject.tag == "Enemy")
			// By using {}, the condition apply to that entire scope, instead of the next line.
		{ 
			print("ca pue");
			cameraanimator.SetBool("Enter", true);
			playeranimator.SetBool("FEAR", true);

		}
	}
	void OnTriggerExit( Collider theCollision )
	{

		if (theCollision.gameObject.tag == "Enemy")
			// By using {}, the condition apply to that entire scope, instead of the next line.
		{ 
			print("ouf");
			cameraanimator.SetBool("Enter", false);
			playeranimator.SetBool("FEAR", false);

		}
	}
}
