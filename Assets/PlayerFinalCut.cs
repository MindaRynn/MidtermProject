using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinalCut : MonoBehaviour {

	Animator anim;
	bool boolper, boolper2, boolper3;
	Rigidbody rb;
	public GameObject faderObj;

	// Use this for initialization
	void Awake () {
		anim = GetComponentInChildren<Animator> ();
		rb = gameObject.GetComponent<Rigidbody> ();
		Death ();
		//		DontDestroyOnLoad (this.transform);

	}

	public void Death () {
		anim.SetBool ("isDeath", true);
	}
}
