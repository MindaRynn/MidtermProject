using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour {

	Animator anim;
	private HealthController health;
	bool boolper, boolper2, boolper3;
	Rigidbody rb;
	public float speed;
	public int jumpCount;
	public int maxBullet;
	private int bulletCount;
	private int bulletCoolDown;
	private int bulletDelayCount;
	private int bulletDelay;
	public bool canMove;
	public bool dialogRunning;
	public GameObject bulletObj;
	public GameObject noticeSign;
	public GameObject faderObj;
	private Fader fader;
	private Vector3 pos;

	// Use this for initialization
	void Awake () {
		anim = GetComponentInChildren<Animator> ();
		health = GetComponentInChildren<HealthController> ();
		rb = gameObject.GetComponent<Rigidbody> ();
		jumpCount = 2;
		bulletCount = maxBullet;
		bulletCoolDown = 0;
		bulletDelay = 20;
		bulletDelayCount = 0;
		noticeSign.GetComponent<Renderer> ().enabled = false;
		fader = faderObj.GetComponent<Fader> ();
		fader.gameObject.SetActive (true);
//		DontDestroyOnLoad (this.transform);
		if (PlayerPrefs.GetString ("PlayerPos") == "" || PlayerPrefs.GetString ("PlayerPos") == null) {
			pos = new Vector3 (0f, 0.7f, 0f);
			transform.position = pos;
		}
		else {
			string[] posStr = PlayerPrefs.GetString ("PlayerPos").Split (',');
			pos = new Vector3 (float.Parse (posStr [0]), float.Parse (posStr [1]), 0f);
			canMove = true;
		}
		transform.position = pos;
	}

	public void Walk () {
		boolper = anim.GetBool("isWalk");
		anim.SetBool ("isWalk", !boolper);
		anim.SetBool ("isRun", false);
		anim.SetBool ("isAnother", false);
		anim.SetBool ("Attack", false);
		anim.SetBool ("LowKick", false);
		anim.SetBool ("isDeath", false);
		anim.SetBool ("isDeath2", false);
		anim.SetBool ("HitStrike", false);
	}

	public void Run () {
		boolper2 = anim.GetBool("isRun");
		anim.SetBool ("isRun", !boolper2);
		anim.SetBool ("isWalk", false);
		anim.SetBool ("isAnother", false);
		anim.SetBool ("Attack", false);
		anim.SetBool ("LowKick", false);
		anim.SetBool ("isDeath", false);
		anim.SetBool ("isDeath2", false);
		anim.SetBool ("HitStrike", false);
	}

	public void OtherIdle () {
		boolper3 = anim.GetBool("isAnother");
		anim.SetBool ("isAnother", !boolper3);
		anim.SetBool ("isWalk", false);
		anim.SetBool ("isRun", false);
		anim.SetBool ("Attack", false);
		anim.SetBool ("LowKick", false);
		anim.SetBool ("isDeath", false);
		anim.SetBool ("isDeath2", false);
		anim.SetBool ("HitStrike", false);
	}

	public void Attack() {
		anim.SetBool ("Attack", true);
	}

	public void LowKick () {
		anim.SetBool ("LowKick", true);
	}

	public void Death () {
		anim.SetBool ("isDeath", true);
	}

	public void Death2 () {
		anim.SetBool ("isDeath2", true);
	}

	public void Strike () {
		anim.SetBool ("HitStrike", true);
	}

	public void Damage () {
		anim.SetBool ("isDamage", true);
	}

	private void Shoot () {
		if (bulletCount > 0 && bulletDelayCount <= 0) {
			bulletCount--;
			bulletDelayCount = bulletDelay;
			BulletController bullet;
			if (IsFacingRight ()) {
				bullet = Instantiate (bulletObj, new Vector3 (transform.position.x + 1f, transform.position.y + 1, transform.position.z), Quaternion.identity).gameObject.GetComponentInParent<BulletController> ();
				bullet.direction = "Right";

			}
			else {
				bullet = Instantiate (bulletObj, new Vector3 (transform.position.x - 1f, transform.position.y + 1, transform.position.z), Quaternion.identity).gameObject.GetComponentInParent<BulletController> ();
				bullet.direction = "Left";
			}
			bullet.shooter = "Player";
			Debug.Log ("Bullet Left: " + bulletCount);
		}
		else {
			Debug.Log ("Out of Bullet!!!");
		}
	}

	public bool IsAnimating () {
		return anim.GetBool ("isWalk") || anim.GetBool ("isRun") || anim.GetBool ("Attack") || anim.GetBool ("LowKick") || anim.GetBool ("isDeath") || anim.GetBool ("isDeath2") || anim.GetBool ("HitStrike");
	}

	private bool IsFacingRight () {
		return transform.eulerAngles.y == 250;
	}

	private void BulletAdder () {
		if (bulletCount < maxBullet) {
			bulletCoolDown++;
		}
		else {
			bulletCoolDown = 0;
		}

		if (bulletCoolDown >= 60) {
			bulletCount++;
			bulletCoolDown = 0;
			Debug.Log ("A Bullet Has been added. Bullet count = " + bulletCount);
			if (bulletCount >= maxBullet) {
				Debug.Log ("MAX BULLET! SHOOT TO BEGIN CHARGING!!!");
			}
		}
	}

	private void BulletDelay () {
		bulletDelayCount--;
		if (bulletDelayCount <= 0) {
			bulletDelayCount = 0;
		}
	}

	private void WalkRight () {
		WalkChecker (1, 250);
	}

	private void WalkLeft () {
		WalkChecker (-1, 50);
	}

	private void WalkChecker (float xPos, float yRotate) {
		Vector3 movementPos = new Vector3 (transform.position.x + xPos, transform.position.y, transform.position.z);
		transform.position = Vector3.MoveTowards (transform.position, movementPos, speed * Time.deltaTime);
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, yRotate, transform.eulerAngles.z);
		noticeSign.transform.rotation = Quaternion.identity;
		if (!IsAnimating ()) {
			Run ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (health.HasDied ()) {
			Debug.Log ("YOU ARE DEAD!!!");
			PlayerPrefs.DeleteKey ("PlayerPos");
			fader.gameObject.SetActive (true);
			fader.FadeOutAndLoad ("GameOver");
			canMove = false;
			health.Heal (100);
			return;
		}

		if (canMove) {

			BulletAdder ();
			BulletDelay ();

			// Shoot a bullet
			if (Input.GetKeyDown (KeyCode.J)) {
				Debug.Log ("Shoot");
				Shoot ();
			}

			// Low kick
			else if (Input.GetKeyDown (KeyCode.K)) {
				Debug.Log ("Attack");
				LowKick ();
			}

			// Attack
			else if (Input.GetKeyDown (KeyCode.L)) {
				Attack ();
			}

			// Jump
			else if (Input.GetKeyDown (KeyCode.Space)) {
				Debug.Log ("Space");
				if (jumpCount > 0) {
					rb.AddForce (Vector2.up * 350f);
					jumpCount--;
				}
			}
			else if (Input.GetKeyDown (KeyCode.H)) {
//				PlayerPrefs.DeleteKey ("PlayerPos");
			}

			// Run right
			else if (Input.GetKey (KeyCode.D)) {
				WalkRight ();
			}

			// Run left
			else if (Input.GetKey (KeyCode.A)) {
				WalkLeft ();
			}

			else if (Input.GetKeyDown (KeyCode.I)) {
				fader.gameObject.SetActive (true);
				fader.FadeIn ();
			}
			else if (Input.GetKeyDown (KeyCode.O)) {
				fader.gameObject.SetActive (true);
				fader.FadeOut ();
			}

			// Idle
			if (Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.A)) {
				OtherIdle ();
			}
		}
		else {
			OtherIdle ();
		}	
	}

	void OnCollisionEnter (Collision obj) {
		Debug.Log (obj.gameObject.tag);
		if (obj.gameObject.tag == "Ground" || obj.gameObject.tag == "Lift" || obj.gameObject.tag == "Bot") {
			jumpCount = 2;
		}
	}
}
