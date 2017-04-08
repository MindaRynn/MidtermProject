using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftMover : MonoBehaviour {
	public int maxHeight;
	public float speed;
	private bool active;
	// Use this for initialization
	void Start () {
		active = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= maxHeight && active) {
			transform.position += new Vector3(0.0f,1.0f,0.0f) * Time.deltaTime * speed;
		}
	}

	public void ActiveLift(){
		active = true;
	}
}
