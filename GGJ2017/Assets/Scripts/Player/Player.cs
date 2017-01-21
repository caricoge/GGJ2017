using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Light halo_prefab;

	// Big Halo cooldown
	public float waitHaloTime = 3f;
	private float haloTimeLeft;
	bool startHaloTimer = false;

	// Use this for initialization
	void Start () {

		haloTimeLeft = waitHaloTime;

	}
	
	// Update is called once per frame
	void Update () {

		if (startHaloTimer) {

			haloTimeLeft -= Time.deltaTime;
			if (haloTimeLeft < 0) {
				haloTimeLeft = waitHaloTime;
				startHaloTimer = false;
			}
		}

		// Left mouse button 
		else if (Input.GetMouseButtonDown (0)) {
			//  Instantiate light object
			Quaternion start_rot = Quaternion.Euler (new Vector3 (90, 0, 0));
			Light halo_light = Instantiate (halo_prefab, transform.position +new Vector3(0,7,0), start_rot);
			startHaloTimer = true;
		}


	}
}
