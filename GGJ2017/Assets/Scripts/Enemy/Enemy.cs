using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public Transform target;
	NavMeshAgent nav_mesh;

	public int detectDistance = 300;

	//Timer to stop when touched by light
	public float waitStopTime = 0.5f;
	private float stopTimeLeft;
	bool startStopTimer = false;

	// Use this for initialization
	void Start () {

		nav_mesh = GetComponent<NavMeshAgent> ();
		stopTimeLeft = waitStopTime;
		nav_mesh.Stop ();
	
	}
	
	// Update is called once per frame
	void Update () {
		nav_mesh.SetDestination (target.position);
		/*
		if (target.GetComponent<Player> ().justClapped) {
			nav_mesh.Resume ();

			Debug.Log ("go");
		}*/
			
		if (startStopTimer) {
			stopTimeLeft -= Time.deltaTime;
			if (stopTimeLeft < 0) {
				nav_mesh.Stop ();
				startStopTimer = false;
				stopTimeLeft = waitStopTime;
				Debug.Log ("Stop");

			}
		}
			
	}

	void FixedUpdate()
	{
		Collider[] colliders = Physics.OverlapSphere (transform.position, detectDistance);
		int i = 0;
		while (i < colliders.Length) 
		{
			if (colliders[i].tag == "Player")
			{
				Player player = colliders [i].GetComponent<Player> ();
				if (player.justClapped || player.justSnapped) 
				{
					nav_mesh.Resume ();
				}
			}
			i++;
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, detectDistance);
	}

	void OnTriggerEnter(Collider collision)
	{
		if(collision.gameObject.tag == "lightRay")
		{
			startStopTimer = true;
			Debug.Log ("touch");
		}
	}
}
