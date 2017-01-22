using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

	bool open = false;

	Animator animator;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider coll)
	{
		if (Input.GetKeyDown (KeyCode.E))
		{
			Debug.Log (coll.gameObject.tag);
			if (coll.gameObject.tag == "Player")
			{
				
				Player player = coll.GetComponent<Player> ();
				Debug.Log (player.HasKey ());
				if (player.HasLever () && !player.IsAfraid()) 
				{
					animator.SetBool ("Activate", true);
					Debug.Log ("Player");
					SceneManager.LoadScene ("Scenes/WinScene");
				}

			}
		}
	}

}
