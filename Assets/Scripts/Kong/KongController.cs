using UnityEngine;
using System.Collections;

public class KongController : MonoBehaviour {

	private float kongSpeed;
	private Rigidbody2D body;
	private Kong kong;

	private bool isFacingRight;
	private bool kongMoving;
	private Vector2 kongDirection;

	public void Start () {
		kongSpeed = 16;

		isFacingRight = true;
		kongMoving = true;

		body = gameObject.GetComponent<Rigidbody2D> ();
		kong = gameObject.GetComponent<Kong> ();

		kongDirection = new Vector2 (1, 0);
	}

	// Update is called once per frame
	void Update () {
		if (kongMoving) {
			//HandleInput ();
			NoInput ();
		}
	}

	public void NoInput () {
		Vector2 currentPosition = new Vector2 (transform.position.x, transform.position.y);
		Vector2 movement = kongDirection * kongSpeed * Time.deltaTime;
		body.MovePosition (currentPosition + movement);
	}

	public void KongStop () {
		body.gravityScale = 0;
		kongMoving = false;
		body.isKinematic = true;
	}

	public void HandleInput () {
		float y = Input.GetAxis ("Vertical");
		float x = Input.GetAxis ("Horizontal");
		
		Vector2 movement = new Vector2 (x, y);
		Vector2 currentPosition = new Vector2 (transform.position.x, transform.position.y);
		
		KongCheckFlip (x);
		
		movement = movement.normalized * kongSpeed * Time.deltaTime;
		body.MovePosition (currentPosition + movement);

		if (Input.GetButtonDown ("Fire1")) {
			//kong.KongBoostFire ();
		} else if (Input.GetButtonDown ("Fire2")) {
			//kong.KongBoostWater ();
		}
	}

	public void SetKongDirection (Transform targetRotation) {
		kongDirection = BodyRotation.GetDirection (targetRotation);
	}

	public void SetKongPosition (Transform targetPosition) {
		transform.position = targetPosition.position;
	}

	public void SetKongMoving (bool state) {
		kongMoving = state;
	}

	public void SetKongSpeed (float speed) {
		kongSpeed = speed;
	}

	public void IsKongKinematic (bool state) {
		body.isKinematic = state;
	}
	
	private void KongCheckFlip (float x) {
		if (isFacingRight) {
			if (x < 0) {
				KongFlip (false);
			}
		} else {
			if (x > 0) {
				KongFlip (true);
			}
		}
	}
	
	private void KongFlip (bool flip) {
		transform.localScale = new Vector3 (-transform.localScale.x, 
			transform.localScale.y, transform.localScale.z);
		isFacingRight = flip;
	}
}