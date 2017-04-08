using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftController : MonoBehaviour {

	public int maxHeight,minHeight;
	public float speed;
	private float x;
	public GameObject scaleFixer;
	// Use this for initialization
	void Start () {
		x = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y >= maxHeight) {
			x = -1.0f;
		}
		else if (transform.position.y <= minHeight) {
			x = 1.0f;
		}
		transform.position += new Vector3(0.0f,x,0.0f) * Time.deltaTime * speed;
	}

	void OnCollisionEnter (Collision obj) {
		if (obj.gameObject.tag == "Player") {
			scaleFixer.transform.parent = transform;
			obj.gameObject.transform.parent = scaleFixer.transform;
		}
	}

	void OnCollisionExit (Collision obj) {
		if (obj.gameObject.tag == "Player") {
			obj.gameObject.transform.parent = null;
			scaleFixer.transform.parent = null;
		}
	}
}
