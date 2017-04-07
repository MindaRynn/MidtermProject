using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {
	public GameObject faderObj;
	private Fader fader;
	// Use this for initialization
	void Start () {
		fader = faderObj.GetComponent<Fader> ();
		fader.gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame(){
		PlayerPrefs.SetString ("PlayerPos", 0 + "," + 0.7);		
		PlayerPrefs.SetInt ("data1", 0);
		PlayerPrefs.SetInt ("data2", 0);
		PlayerPrefs.SetInt ("data3", 0);
		PlayerPrefs.SetInt ("data4", 0);
		PlayerPrefs.SetInt ("data5", 0);
		PlayerPrefs.SetInt ("moveCam1", 0);
		fader.gameObject.SetActive (true);
		fader.FadeOutAndLoad ("MainStage1");
	}
}
