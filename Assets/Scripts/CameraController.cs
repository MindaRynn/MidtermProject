using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Awake () {
		offset = new Vector3 (4.5f, 5f, -14f);
	}

	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + offset;
	}
}
