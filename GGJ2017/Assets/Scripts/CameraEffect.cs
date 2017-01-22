using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraEffect : MonoBehaviour {


	public Animator cameraanimator;
	public Animator playeranimator;

	public float waitDeathTime = 1.6f;
	private float deathTimeLeft;
	private bool startDeathTimer = false ;


	Player player;

//	public GameObject Enemy;
	// Use this for initialization
	void Start () {
		
		cameraanimator.SetFloat("speed", 0);
		deathTimeLeft = waitDeathTime;


	}
	void Update(){

		if(Input.GetButtonDown("Fire2")){

			playeranimator.SetBool("Fire2",true);

		}

		else {

			//playeranimator.SetBool("Fire2",false);

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

		if (startDeathTimer)
		{
			deathTimeLeft -= Time.deltaTime;
			if(deathTimeLeft < 0)
			{
				Die();
				deathTimeLeft = waitDeathTime;
			}
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

	// Update is called once per frame
	void OnTriggerStay( Collider theCollision )
	{

		if (theCollision.gameObject.tag == "Enemy")
			// By using {}, the condition apply to that entire scope, instead of the next line.
		{ 
			//Distance between player and enemy
			float delta = Vector3.Distance(transform.position, theCollision.transform.position);
			Debug.Log (delta);

			if (delta < 1.6f) {
				startDeathTimer = true;
			}
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

	void Die()
	{
		SceneManager.LoadScene ("Scenes/GameOver");
	}
}
