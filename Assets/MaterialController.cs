using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour {
	public Material texture;
	public GameObject mummy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Changing(){
		mummy.GetComponent<Renderer> ().material = texture;
	}
}
