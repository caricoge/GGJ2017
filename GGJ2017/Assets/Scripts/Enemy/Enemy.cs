using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public Transform target;
	NavMeshAgent nav_mesh;

	// Use this for initialization
	void Start () {

		nav_mesh = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (target.GetComponent<Player> ().justClapped) {
			nav_mesh.Resume ();
			nav_mesh.SetDestination (target.position);
			Debug.Log ("go");
		}


		
	}

	void OnTriggerEnter(Collider collision)
	{
		Debug.Log (collision.gameObject.tag);
		if(collision.gameObject.tag == "lightRay")
		{
			nav_mesh.Stop ();
			Debug.Log ("Stop");
		}
	}
}
