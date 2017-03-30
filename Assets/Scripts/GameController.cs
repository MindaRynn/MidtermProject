using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public AudioClip bgSound;

	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint(bgSound, transform.position,1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
