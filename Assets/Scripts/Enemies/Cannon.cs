using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cannon : MonoBehaviour {
	public GameObject trajectory;
	public GameObject ball;
	public Transform target;

	private Vector2 velocity;
	public Vector2 direction;
	private bool isPressed, isFired;

	public void Start () {
		isFired = false;
		isPressed = false;
		CreateBall ();
	}

	public void Update () {
		if(isFired) {
			return;
		}

		if(Input.GetMouseButtonDown (0)) {
			isPressed = true;
			if(!isFired) {
				Fire ();
			}
		}
	}

	private void CreateBall() {
		ball.SetActive(true);
	}

	private void Fire () {
		if (direction.y != 0 && direction.x != 0) {
			velocity = CalculateBallisticVelocity (transform, target, Mathf.Atan2 (direction.x, direction.y));
		} else {
			velocity = direction * 10f;
		}

		ball.SetActive (true);
		ball.GetComponent<Rigidbody2D> ().gravityScale = 1;
		ball.GetComponent<Rigidbody2D> ().AddForce (velocity, ForceMode2D.Impulse);
		isFired = true;
	}

	public Vector2 CalculateBallisticVelocity(Transform source, Transform target, float angle) {
		float distance = (target.position - source.position).magnitude;
		float velocity = Mathf.Sqrt(distance * Mathf.Abs (Physics2D.gravity.y) / (Mathf.Sin (2 * angle)));
		return new Vector2 (Mathf.Sin (angle), Mathf.Cos (angle)) * velocity;
	}
}