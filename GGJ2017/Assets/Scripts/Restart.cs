using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	Animator animator;
	int restartNameCode;
	// Use this for initialization
	void Start () {

		animator = FindObjectOfType<Canvas> ().GetComponent<Animator>();
		restartNameCode = Animator.StringToHash ("Base.Restart");
		Debug.Log (animator.gameObject);
	}
	
	// Update is called once per frame
	void Update () {

		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Restart")) {
			SceneManager.LoadScene ("Scenes/TestCharacter");

		}
	}
}
