using UnityEngine;
using System.Collections;

public class MotorParallelWave : Motor {
	public Vector2 velocity;
	private Vector2 direction;

	public GameObject target;
	public float wait;

	private Vector3 currentPosition;
	private Coroutine coroutine;

	// Use this for initialization
	void Start () {}
	
	public override void Move () {
		coroutine = Coroutine.Make (MoveCo ());
		coroutine.Start ();
	}

	public override void Stop () {
		coroutine.KillCoroutine ();
	}

	public void Update () {
		velocity = target.GetComponent<Rigidbody2D> ().velocity;
	}

	public IEnumerator MoveCo () {
		while (true) {
			if (velocity.x != 0) {
				Vector3 targetPosition = new Vector3 (target.transform.position.x, transform.position.y, 0);
				currentPosition = Vector3.MoveTowards (transform.position, targetPosition, velocity.magnitude * Time.deltaTime);
			} else if (velocity.y != 0) {
				Vector3 targetPosition = new Vector3 (transform.position.x, target.transform.position.y, 0);
				currentPosition = Vector3.MoveTowards (transform.position, targetPosition, velocity.magnitude * Time.deltaTime);
			}
			transform.position = currentPosition;
			
			yield return 0;
		}
    }
}