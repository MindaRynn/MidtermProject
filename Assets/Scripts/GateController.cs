using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour {
	public GameObject explosion;
	public GameObject cube1; 
//	cube2, cube3, cube4, cube5, cube6, cube7, cube8, cube9, cube10, cube11, cube12, cube13;
	// Use this for initialization
	public void DestroyGate(){
		Instantiate (explosion, cube1.transform.position, cube1.transform.rotation);
		Destroy (gameObject);
	}
}
