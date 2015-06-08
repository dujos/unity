using UnityEngine;
using System.Collections;

public class MotorStraightWave : Motor {
	public Vector2 velocity;
	private Vector2 direction;
	
	private Vector3 startPosition;
	private Vector3 currentPosition;
	public Vector3 targetPosition;

	public float wait;
	private Coroutine coroutine;
	private Rigidbody2D body;
	
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		currentPosition = startPosition;

		Vector3 temp = (targetPosition - startPosition).normalized;
		direction = new Vector2 (temp.x, temp.y);
		velocity = velocity.magnitude * direction;

		body = GetComponent<Rigidbody2D> ();
	}

	public override void Move () {
		coroutine = Coroutine.Make (MoveCo ());
		coroutine.Start ();
	}

	public override void Stop () {
		coroutine.KillCoroutine ();

		velocity = velocity.magnitude * direction * (-1);
		body.AddForce (velocity, ForceMode2D.Impulse);
		velocity = velocity.magnitude * direction;
	}

	public void Update () {}

	public IEnumerator MoveCo () {
		body.AddForce (velocity, ForceMode2D.Impulse);

		while (true) {
			currentPosition = Vector3.MoveTowards (transform.position, targetPosition, velocity.magnitude * Time.deltaTime);
			//transform.position = currentPosition;
			//body.MovePosition (Geometry.Vec2 (currentPosition));

			if (currentPosition == targetPosition) {
				var position = startPosition;
				startPosition = targetPosition;
				targetPosition = position;
				
				direction = Geometry.Direction (targetPosition, transform.position);

				velocity = velocity.magnitude * direction;
				body.AddForce (velocity, ForceMode2D.Impulse);
				velocity = velocity.magnitude * direction;
				body.AddForce (velocity, ForceMode2D.Impulse);

				yield return new WaitForSeconds (wait);
			}

			yield return 0;
        }
    }
}