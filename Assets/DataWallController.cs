using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataWallController : MonoBehaviour {

	public GameObject wall1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("data1") == 1) {
			Destroy (wall1);	
		}
	}
}
