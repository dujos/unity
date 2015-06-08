using UnityEngine;
using System.Collections;

public class MotorWarp : Motor {
	public Transform target;
	public float wait;
	
	private Vector2 currentPosition;

	// Use this for initialization
	void Start () {
		currentPosition = new Vector2 (transform.position.x, transform.position.y);

		Move ();
	}

	public override void Move () {
		StartCoroutine (MoveCo ());
	}

	public IEnumerator MoveCo () {
		yield return new WaitForSeconds (wait);
		currentPosition = new Vector2 (target.position.x, target.position.y);
		//body.MovePosition (currentPosition);
	}

	public IEnumerator WaitCo () {
		yield return new WaitForSeconds (wait);
	}
}