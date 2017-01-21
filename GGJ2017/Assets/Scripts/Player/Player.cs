using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Light halo_prefab;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		// Left mouse button 
		if (Input.GetMouseButtonDown (0)) {
			//  Instantiate light object
			Quaternion start_rot = Quaternion.Euler (new Vector3 (90, 0, 0));
			Light halo_light = Instantiate (halo_prefab, transform.position +new Vector3(0,7,0), start_rot);
		}
	}
}
