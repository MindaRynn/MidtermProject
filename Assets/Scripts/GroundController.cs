using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour {

	public float maxHight,minHight;
	public Rigidbody rb;
	public float speed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y >= 20 ||(transform.position.y <= 5)) {
			speed = speed * (-1);
		}

		rb.MovePosition(transform.position + new Vector3(0.0f,speed,0.0f));
	}
}
