using UnityEngine;
using System.Collections;

public class MotorStraight : Motor {
	public Vector2 velocity;
	private Rigidbody2D body;
	private Vector2 currentPosition;
	private Coroutine coroutine;
	
	// Use this for initialization
	public void Start () {
		currentPosition = new Vector2 (transform.position.x, transform.position.y);
		body = gameObject.GetComponent<Rigidbody2D> ();
	}

	public override void Move () {
		coroutine = Coroutine.Make (MoveCo ());
		coroutine.Start ();
	}

	public void MoveTowards (Vector2 target) {
		coroutine = Coroutine.Make (MoveTowardsCo (target));
		coroutine.Start ();
	}

	public void Stop () {
		coroutine.KillCoroutine ();
	}

	public void Update () {}

	private IEnumerator MoveTowardsCo (Vector2 target) {
		do {
			currentPosition = Vector2.MoveTowards (Geometry.Vec2 (transform), target, velocity.magnitude * Time.deltaTime);
			transform.position = Geometry.Vec3 (currentPosition);
			yield return 0;
		} while (currentPosition != target);
	}

	private IEnumerator MoveCo () {
		while (true) {
			currentPosition = new Vector2 (transform.position.x, transform.position.y);
			body.MovePosition (currentPosition + velocity * Time.deltaTime);
			yield return 0;
		}
	}

	public void MoveWithForce () {
		body.AddForce (velocity, ForceMode2D.Impulse);
	}
}