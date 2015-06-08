using UnityEngine;
using System.Collections;

public class MotorParabolic : Motor {
	private Vector2 velocity;
	
	private Vector3 startPosition;
	public Transform targetPosition;
	private Vector3 currentPosition;
	
	public float wait;
	public float angle;
	
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		currentPosition = startPosition;
		
		Move ();
	}
	
	public void Move () {
		StartCoroutine (MoveCo ());
	}

	public IEnumerator MoveCo () {
		yield return new WaitForSeconds (wait);
		velocity = CalculateVelocity ();
		//body.AddForce (velocity, ForceMode2D.Impulse);
	}

	public Vector2 CalculateVelocity () {
		float distance = Mathf.Abs (startPosition.x - targetPosition.position.x);
		float h = startPosition.y - targetPosition.position.y;
		float height = h > 0 ? h : Mathf.Abs(h);
		//body.gravityScale = h >= 0 ? 1 : -1;

		angle = angle * Mathf.Deg2Rad;
		float bottom = distance*Mathf.Sin(2*angle) + 2*height*Mathf.Cos(angle)*Mathf.Cos(angle);
		float result = Mathf.Sqrt (distance*distance*10 / bottom);
		float temp = h >= 0 ? result * Mathf.Sin (angle) : -result * Mathf.Sin (angle);
		return new Vector2 (result * Mathf.Cos (angle), temp);
	}
}