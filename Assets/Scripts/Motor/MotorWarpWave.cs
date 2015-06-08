using UnityEngine;
using System.Collections;

public class MotorWarpWave : Motor {
	public Transform target;
	public float wait;
	
	private Vector2 currentPosition;
	private Vector2 nextPosition;
	
	// Use this for initialization
	void Start () {
		currentPosition = new Vector2 (transform.position.x, transform.position.y);
		nextPosition = new Vector2 (target.position.x, target.position.y);
		
		Move ();
	}
	
	public override void Move () {
		StartCoroutine (MoveCo ());
	}

	public IEnumerator MoveCo () {
		while (true) {
			yield return new WaitForSeconds (wait);

			var temp = currentPosition;
			currentPosition = nextPosition;
			nextPosition = temp;

			//body.MovePosition (currentPosition);

			yield return 0;
		}
	}

	public IEnumerator WaitCo () {
		yield return new WaitForSeconds (wait);
	}
}