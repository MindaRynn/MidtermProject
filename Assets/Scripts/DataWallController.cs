using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataWallController : MonoBehaviour {

	public GameObject wall1, block1;
	public GameObject liftColl;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("data1") == 0) {
			wall1.gameObject.SetActive (true);
		} else {
			Destroy (block1);
		}
	}
}
