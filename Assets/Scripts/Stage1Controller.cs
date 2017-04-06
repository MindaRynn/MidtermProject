using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Controller : MonoBehaviour {

	public GameObject zombiePrefab;
	private Vector3[] zombiesPos;

	// Use this for initialization
	void Awake () {
		InitializeZombiesPos ();
		InstantiateZombies ();
	}

	private void InitializeZombiesPos () {
		Debug.Log ("InitializeZombiesPos");
		zombiesPos = new Vector3[5];
		zombiesPos[0] = new Vector3 (30, 1, 0);
		zombiesPos[1] = new Vector3 (50, 1, 0);
		zombiesPos[2] = new Vector3 (70, 1, 0);
		zombiesPos[3] = new Vector3 (90, 1, 0);
		zombiesPos[4] = new Vector3 (110, 1, 0);
	}

	private void InstantiateZombies () {
		Debug.Log ("InstantiateZombies");
		for (int i = 0; i < zombiesPos.Length; i++) {
			Instantiate (zombiePrefab, zombiesPos [i], Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
