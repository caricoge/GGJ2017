using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Light halo_prefab;

	bool hasKey = false;

	Animator animator;

	// Small Spark cooldown
	public float waitSparkTime = 3f;
	private float sparkTimeLeft;
	bool startSparkTimer = false;

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
				Debug.Log ("eeeeeeee");
				sparkTimeLeft = waitSparkTime;
				startSparkTimer = false;
				animator.SetBool ("SparkCoolDown",false);
			}
		}
			
		// Left mouse button 
		if (Input.GetButtonDown("Fire1")) {

			if (!startHaloTimer) {
				//  Instantiate light object
				Quaternion start_rot = Quaternion.Euler (new Vector3 (90, 0, 0));
				Light halo_light = Instantiate (halo_prefab, transform.position +new Vector3(0,5,0), start_rot);

				startHaloTimer = true;
				justClapped = true;
			}
		}

		if (Input.GetButtonDown ("Fire2")) {

			if (!startSparkTimer) {
				//  Instantiate light object
				Quaternion start_rot = Quaternion.Euler (new Vector3 (90, 0, 0));
				Light halo_light = Instantiate (halo_prefab, transform.position + new Vector3 (0, 5, 0), start_rot);
				Debug.Log (startSparkTimer);

				startSparkTimer = true;
				justSnapped = true;

			}
		}

	}
}
