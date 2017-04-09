using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour {
	public GameObject explosion;
	public GameObject cube1,cube2, cube3, cube4, cube5, cube6, cube7, cube8, cube9, cube10, cube11, cube12, cube13;
	// Use this for initialization
	public void DestroyGate(){
		Instantiate (explosion, cube1.transform.position, cube1.transform.rotation);
		Instantiate (explosion, cube2.transform.position, cube1.transform.rotation);
		Instantiate (explosion, cube3.transform.position, cube1.transform.rotation);
		Instantiate (explosion, cube4.transform.position, cube1.transform.rotation);
		Instantiate (explosion, cube5.transform.position, cube1.transform.rotation);
		Instantiate (explosion, cube6.transform.position, cube1.transform.rotation);
		Instantiate (explosion, cube7.transform.position, cube1.transform.rotation);
		Instantiate (explosion, cube8.transform.position, cube1.transform.rotation);
		Instantiate (explosion, cube9.transform.position, cube1.transform.rotation);
		Instantiate (explosion, cube10.transform.position, cube1.transform.rotation);
		Instantiate (explosion, cube11.transform.position, cube1.transform.rotation);
		Instantiate (explosion, cube12.transform.position, cube1.transform.rotation);
		Instantiate (explosion, cube13.transform.position, cube1.transform.rotation);
		Destroy (gameObject);
	}
}
