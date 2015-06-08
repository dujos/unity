using UnityEngine;
using System.Collections;

public class MotorParallel : Motor {
	public Vector2 velocity;
	private Vector2 direction;

	public Transform target;
	public float wait;

	private Vector3 targetPosition;
	private Vector3 offsetPosition;
	private Vector3 currentPosition;

	private Coroutine coroutine;

	// Use this for initialization
	void Start () {
		targetPosition = new Vector3 (transform.position.x, target.position.y, 0);

		Vector3 temp = (targetPosition - transform.position).normalized;
		direction = new Vector2 (temp.x, temp.y);
		velocity = velocity.magnitude * direction;
	}
	
	public override void Move () {
		coroutine = Coroutine.Make (MoveCo ());
		coroutine.Start ();
	}

	public override void Stop () {
		coroutine.KillCoroutine ();
	}

	public IEnumerator MoveCo () {
		offsetPosition = Vector3.MoveTowards (transform.position, target.position, velocity.magnitude * Time.deltaTime);
		currentPosition = new Vector3 (transform.position.x, offsetPosition.y, 0);
		transform.position = currentPosition;

		if (currentPosition.y == target.position.y) {
			velocity *= -1;
			targetPosition = new Vector3 (transform.position.x, targetPosition.y, 0);
            yield return new WaitForSeconds (wait);
		}

		/*
		else {
			Vector3 temp = (currentPosition - transform.position).normalized;
			direction = new Vector2 (temp.x, temp.y);
			velocity = velocity.magnitude * direction;
		}
		*/
        yield return 0;
    }
}