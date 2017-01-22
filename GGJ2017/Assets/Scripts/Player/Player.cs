using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject halo_prefab;
	public Light spark_prefab;

	bool hasKey = false;

	Animator animator;

	GameObject halo_shield;

	// Small Spark cooldown
	public float waitSparkTime = 3f;
	private float sparkTimeLeft;
	bool startSparkTimer = false;

	int matches = 3;

	// Big Halo cooldown
	public float waitHaloTime = 3f;
	private float haloTimeLeft;
	bool startHaloTimer = false;

	public bool justClapped = false;
	public bool justSnapped = false;

	// Use this for initialization
	void Start () {

		haloTimeLeft = waitHaloTime;
		sparkTimeLeft = waitSparkTime;

		Animator[] animators = GetComponentsInChildren<Animator> ();

		foreach (Animator a in animators) 
		{
			if (a.gameObject.tag != "MainCamera") {
				animator = a;
			}
		}

	}
	// Update is called once per frame
	void Update () {

		//Halo Timer
		if (startHaloTimer) {

			if (justClapped) {
				justClapped = false;
				animator.SetBool ("HaloCoolDown", true);
			}
			haloTimeLeft -= Time.deltaTime;

			//End of Halo Cooldown
			if (haloTimeLeft < 0) {
				
				haloTimeLeft = waitHaloTime;
				startHaloTimer = false;
				animator.SetBool ("HaloCoolDown",false);
			}
		}

		//Spark
		if (startSparkTimer) {

			if (justSnapped) {
				justSnapped = false;
				animator.SetBool ("SparkCoolDown", true);
			}
			sparkTimeLeft -= Time.deltaTime;

			//End of Spark Cooldown
			if (sparkTimeLeft < 0) {
				sparkTimeLeft = waitSparkTime;
				startSparkTimer = false;
				animator.SetBool ("SparkCoolDown",false);
				animator.SetBool ("Fire2",false);
			}
		}
			
		// Left mouse button 
		if (Input.GetButtonDown("Fire1")) {

			if (!startHaloTimer && !IsAfraid()) {
				// Instantiate light object
				Quaternion start_rot = Quaternion.Euler (new Vector3 (90, 0, 0));
				Instantiate (halo_prefab, transform.position, start_rot);

				startHaloTimer = true;
				justClapped = true;
			}
		}

		// SPARK
		if (Input.GetButtonDown ("Fire2")) {
			
			// Matches
			if (!startSparkTimer && !IsAfraid()) {
				//  Instantiate light object
				Quaternion start_rot = Quaternion.Euler (new Vector3 (90, 0, 0));
				Instantiate (spark_prefab, transform.position + new Vector3 (0, 5, 0), start_rot);

				startSparkTimer = true;
				justSnapped = true;

				// A match is used
				matches--;


			}
		}

		if (Input.GetButtonUp ("Fire2")) 
		{
			animator.SetBool ("Fire2",false);
		}
			

	}

	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "key") {
			
			animator.SetBool ("CanGrab", true);

		}
	}

	void OnTriggerStay(Collider collision)
	{
		if (collision.tag == "key") {

			if (Input.GetKeyDown (KeyCode.E) && !IsAfraid()) {
				hasKey = true;
				Destroy (collision.gameObject);
			}
		}

	}

	void OnTriggerExit(Collider collision)
	{
		if (collision.gameObject.tag == "key") {
			animator.SetBool ("CanGrab", false);
		}
	}

	public bool IsAfraid()
	{
		return animator.GetBool ("FEAR");
	}

	public bool HasKey()
	{
		return hasKey;
	}


}
