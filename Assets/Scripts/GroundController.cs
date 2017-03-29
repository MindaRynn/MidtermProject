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
		if (transform.position.y >= maxHight ||(transform.position.y <= minHight)) {
			speed = speed * (-1);
		}

		rb.MovePosition(transform.position + new Vector3(0.0f,speed,0.0f));
	}
}
