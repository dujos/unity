using UnityEngine;
using System.Collections;

public class MotorCircle : Motor {
	private float angle;
	private float speed;
	private Rigidbody2D body;
	public float radius;
	public float frequency;
	public Transform center;

	private Vector2 currentPosition;

	public void Awake () {
		angle = 0;
		speed = (2 * Mathf.PI) / frequency;
		currentPosition = new Vector2 (transform.position.x, transform.position.y);
		body = gameObject.GetComponent<Rigidbody2D> ();

		Move ();
	}

	public override void Move () {
		StartCoroutine (MoveCo ());
	}
	
	private IEnumerator MoveCo () {
		while (true) {
			angle += speed * Time.deltaTime;
			float x = Mathf.Cos (angle) * radius;
			float y = Mathf.Sin (angle) * radius;

			currentPosition = new Vector2 (center.position.x, center.position.y) + new Vector2 (x, y);
			body.MovePosition (currentPosition);

			yield return 0;
		}
	}
}