using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halo_Wave: MonoBehaviour {

	Transform player;

	Light halo_light;
	public float speed = 1f;

	SphereCollider lightTrigger;

	//Destroy timer
	public float waitDestroyTime = 1f;
	private float destroyTimeLeft;
	bool startDestroyTimer = false;

	// Use this for initialization
	void Start () 
	{
		halo_light = GetComponent<Light> ();
		//halo_light.cookieSize = 0;
		startDestroyTimer = true;
		
		//Init timer
		destroyTimeLeft = waitDestroyTime;

		player = FindObjectOfType<Player> ().transform;

		lightTrigger = GetComponentInChildren<SphereCollider> ();
		/*Vector3 pos = lightTrigger.transform.position;
		pos.y = 0;
		lightTrigger.transform.position = pos;
		*/
	}
	
	// Update is called once per frame
	void Update () 
	{
		//transform.position = player.position;

		//enlarge halo over time
		halo_light.spotAngle += speed;
		lightTrigger.radius += speed/100;
		float coeff = speed/100 * Time.deltaTime;

		Debug.Log (transform.localScale);
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
