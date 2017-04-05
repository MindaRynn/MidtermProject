using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

	private int hp;
	public int maxHP;
	public Image hpBar;
	public Text hpText;

	// Use this for initialization
	void Awake () {
		hp = maxHP;
		UpdateHP ();
	}

	void Update () {
		
	}

	private void UpdateHP () {
		hpBar.transform.localScale = new Vector3 ((hp + 0f) / maxHP, 1, 1);
		hpText.text = hp + "/" + maxHP;
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
