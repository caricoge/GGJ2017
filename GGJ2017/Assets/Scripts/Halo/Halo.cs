using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halo : MonoBehaviour {

	Transform player;

	Light halo_light;
	public float speed = 1f;

	//Destroy timer
	public float waitDestroyTime = 1f;
	private float destroyTimeLeft;
	bool startDestroyTimer = false;

	// Use this for initialization
	void Start () {

		halo_light = GetComponent<Light> ();
		halo_light.cookieSize = 0;
		startDestroyTimer = true;

		//Init timer
		destroyTimeLeft = waitDestroyTime;

		player = FindObjectOfType<Player> ().transform;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		float player_y = player.localRotation.eulerAngles.y;

		Vector3 cur_rot = transform.localRotation.eulerAngles;
		Quaternion new_rot = Quaternion.Euler(new Vector3(cur_rot.x, player_y, cur_rot.z));
		transform.localRotation = new_rot;
	
		Debug.Log(player.localRotation.eulerAngles.y +" "+ transform.localRotation.eulerAngles.y);
	*/
		//enlarge halo over time
		halo_light.spotAngle += speed;

		//Start counting before destroy
		if (startDestroyTimer)
		{
			//decrement timer
			destroyTimeLeft -= Time.deltaTime;

			//end of timer
			if (destroyTimeLeft < 0) 
			{
				Destroy (gameObject);
				startDestroyTimer = false;
			}
		}


	}
}
