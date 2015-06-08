using UnityEngine;
using System.Collections;

public class MotorCosinus : Motor {
	public float frequency;
	public Vector2 velocity;

	private Vector2 axis;
	private Vector2 currentPosition;
	private Rigidbody2D body;
	private Coroutine coroutine;

	void Start () {
		body = GetComponent<Rigidbody2D> ();
		currentPosition = Geometry.Vec2 (transform.position);
		axis = Vector2.right;
	}

	public override void Move () {
		coroutine = Coroutine.Make (MoveCo ());
		coroutine.Start ();
	}
	
	public override void Stop () {
		coroutine.KillCoroutine ();
	}

	public IEnumerator MoveCo () {
		while (true) {
			currentPosition += Vector2.up * Time.deltaTime * velocity.magnitude;
			body.MovePosition (currentPosition + axis * Mathf.Sin (Time.time * frequency) * velocity.magnitude);
			yield return 0;
		}
	}
}