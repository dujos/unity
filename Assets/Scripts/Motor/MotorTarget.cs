using UnityEngine;
using System.Collections;

public class MotorTarget : Motor {
	private Vector2 direction;
	private Rigidbody2D body;
	public Transform target;
	public Vector2 velocity;

	private Coroutine coroutine;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
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
			Vector3 currentPosition = Vector3.MoveTowards (transform.position, target.position, velocity.magnitude * Time.deltaTime);
			body.MovePosition (Geometry.Vec2 (currentPosition));
			yield return 0;
		}
	}
}
