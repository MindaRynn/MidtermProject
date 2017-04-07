using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {
	public Button startBut;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void hover(){
		startBut.gameObject.GetComponentInChildren<Image>().color = new Color(0,0,0, 0.56F);
	}
}
