using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataWallController : MonoBehaviour {

	public GameObject wall1, block1;
	public GameObject wall2, block2;
	public GameObject serverBlock;

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

		if (PlayerPrefs.GetInt ("data2") == 0||PlayerPrefs.GetInt ("data3") == 0||PlayerPrefs.GetInt ("data4") == 0) {
			wall2.gameObject.SetActive (true);
		} else {
			Destroy (block2);
		}

		if (PlayerPrefs.GetInt ("isDoctorDied") == 1) {
			Destroy (serverBlock);
		}
	}
}
