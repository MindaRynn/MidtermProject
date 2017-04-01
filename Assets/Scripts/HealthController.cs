using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

	private int hp;
	public int maxHP;
	public Text hpText;

	// Use this for initialization
	void Awake () {
		hp = maxHP;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.H)) {
			Heal (5);
		}
	}

	private void UpdateHP () {
		hpText.text = hp.ToString ();
	}

	public void Heal (int healPoint) {
		hp += healPoint;
		if (hp > maxHP) {
			hp = maxHP;
		}
		UpdateHP ();
	}

	public void Damage (int damagePoint) {
		hp -= damagePoint;
		if (hp < 0) {
			hp = 0;
		}
		UpdateHP ();
	}

	public int GetHP () {
		return hp;
	}

	public bool HasDied () {
		return hp <= 0;
	}
}
