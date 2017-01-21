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
		Debug.Log (nav_mesh);
	}
	
	// Update is called once per frame
	void Update () {
		nav_mesh.SetDestination (target.position);


	}
}
