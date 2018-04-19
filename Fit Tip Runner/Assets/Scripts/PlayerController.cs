using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	const float TOP = 2.5f;
	const float BOTTOM = -3f;
	Animator anim;
	public float moveForce = .3f;
	Rigidbody2D myBody;
	bool isHeadphonesInUse = false;

	// Use this for initialization
	void Start ()
	{
		myBody = this.GetComponent<Rigidbody2D> ();
		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Vector2 moveVec = new Vector2 (CrossPlatformInputManager.GetAxis ("Horizontal"), CrossPlatformInputManager.GetAxis ("Vertical")) * moveForce;
		bool isUsingHeadphones = CrossPlatformInputManager.GetButton ("UseHeadphones");
		if (!isUsingHeadphones) {
//			myBody.AddForce (moveVec);
			myBody.velocity = moveVec;
			anim.SetInteger ("State", 1); // run
		}
		CheckBorders ();

		if (moveVec.x == 0) {
			if (!isHeadphonesInUse) {
				anim.SetInteger ("State", 0); // idle
			} else if (isHeadphonesInUse) {
				anim.SetInteger ("State", 3); // idle with hedphones
			}
		}
//		if (isUsingHeadphones) {
//			if (isUsingHeadphones) {
//				anim.SetInteger ("State", 2); // putting headphones on
//				isUsingHeadphones = true;
//			} else {
//				anim.SetInteger ("State", 4); // taking headphones off
//				isUsingHeadphones = false;
//			}
//		}
	}

	public void usingHeadphones() {
		if (isHeadphonesInUse) {
			anim.SetInteger ("State", 2); // putting headphones on
			isHeadphonesInUse = true;
		} else {
			anim.SetInteger ("State", 4); // taking headphones off
			isHeadphonesInUse = false;
		}
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag ("Border Top")) {
			Debug.Log ("Top hit");
			myBody.position.Set(myBody.position.x, TOP);
		} else if (other.gameObject.CompareTag ("Border Bottom")) {
			Debug.Log ("Bottom hit");
			myBody.position.Set(myBody.position.x, BOTTOM);
		}
	}

	private void OnTriggerEnter2D (Collider2D other)
	{
		switch (other.gameObject.tag) {
		case "Border Top":
			Debug.Log ("Top hit");
			myBody.position.Set (myBody.position.x, TOP);
			break;
		case "Border Bottom":
			Debug.Log ("Bottom hit");
			myBody.position.Set(myBody.position.x, BOTTOM);
			break;
		case "Exit":
			GoalReached.instance.isGoalReached = true;
			break;
		default:
			break;
		}
	}

	private void CheckBorders() {
		if (myBody.position.y > TOP) {
			Debug.Log ("Top hit");
			this.gameObject.transform.SetPositionAndRotation (new Vector3 (myBody.position.x, TOP), Quaternion.identity);
//			myBody.position.Set (myBody.position.x, TOP);
		} else if (myBody.position.y < BOTTOM) {
			Debug.Log ("Bottom hit");
			this.gameObject.transform.SetPositionAndRotation (new Vector3 (myBody.position.x, BOTTOM), Quaternion.identity);
			myBody.position.Set (myBody.position.x, BOTTOM);
		}
	}
}