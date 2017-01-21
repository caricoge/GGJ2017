using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	bool open = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (open) {
			transform.Translate (Vector3.down * Time.deltaTime * 1.5f);
		}
	}

	void OnTriggerStay(Collider coll)
	{
		
		if (Input.GetKeyDown (KeyCode.E))
		{
			Debug.Log ("Click");
			if (coll.gameObject.tag == "Player")
			{
				Debug.Log ("Player");
				Player player = coll.GetComponent<Player> ();

				if (player.HasKey () && !player.IsAfraid()) {
					open = true;
				}
			}

		}


	}
}
