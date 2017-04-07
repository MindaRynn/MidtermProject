using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

	private Animator anim;
	private GameObject player;
	bool boolper, boolper2, boolper3;
	Rigidbody rb;
	public float speed;
	public int jumpCount;
	public int maxBullet;
	private bool right;
	private int walkTime;
	private int bulletDelay;
	private int radiusRange;
	private int jumpTime;
	public GameObject bulletObj;
	public GameObject hpBar;

	// Use this for initialization
	void Awake () {
		anim = GetComponentInChildren<Animator>();
		player = GameObject.Find ("Player").gameObject;
		rb = gameObject.GetComponent<Rigidbody> ();
		jumpCount = 2;
		right = true;
		walkTime = 0;
		bulletDelay = 0;
		radiusRange = 10;
		jumpTime = 0;
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

	public bool IsAnimating () {
		return anim.GetBool ("isWalk") || anim.GetBool ("isRun") || anim.GetBool ("Attack") || anim.GetBool ("LowKick") || anim.GetBool ("isDeath") || anim.GetBool ("isDeath2") || anim.GetBool ("HitStrike");
	}

	private void Shoot ()
	{
		BulletController bullet;
		if (IsFacingRight ()) {
			bullet = Instantiate (bulletObj, new Vector3 (transform.position.x + 1f, transform.position.y + 1, transform.position.z), Quaternion.identity).gameObject.GetComponentInParent<BulletController> ();
			bullet.direction = "Right";
		}
		else {
			bullet = Instantiate (bulletObj, new Vector3 (transform.position.x - 1f, transform.position.y + 1, transform.position.z), Quaternion.identity).gameObject.GetComponentInParent<BulletController> ();
			bullet.direction = "Left";
		}
		bullet.shooter = "Bot";
	}

	private bool IsFacingRight () {
		return transform.eulerAngles.y == 250;
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
		hpBar.transform.rotation = Quaternion.identity;
		if (!IsAnimating ()) {
			Run ();
		}
	}

	private int RandomTime (int min, int max) {
		return Random.Range (min, max);
	}

	private void RandomWalkSide () {
		right = !right;
	}

	private bool IsPlayerInRangeX () {
		return Mathf.Abs (transform.position.x - player.gameObject.transform.position.x) <= radiusRange;
	}

	private bool IsPlayerInRangeY () {
		return Mathf.Abs (transform.position.y - player.gameObject.transform.position.y) <= radiusRange;
	}

	void Update () {
		if (IsPlayerInRangeX () && IsPlayerInRangeY ()) {
			if (transform.position.x < player.gameObject.transform.position.x) {
				WalkRight ();
			}
			else if (transform.position.x > player.gameObject.transform.position.x) {
				WalkLeft ();
			}
			if (bulletDelay <= 0) {
				Shoot ();
				bulletDelay = 60;
			}
			else {
				bulletDelay--;
			}
			if (jumpTime <= 0) {
				rb.AddForce (Vector2.up * 300f);
				jumpTime = RandomTime (60, 120);
			}
			jumpTime--;
		}
		else {
			if (walkTime <= 0) {
				walkTime = RandomTime (40, 180);
				RandomWalkSide ();
			}
			if (right) {
				WalkRight ();
			}
			else {
				WalkLeft ();
			}
			walkTime--;
		}
	}
}
