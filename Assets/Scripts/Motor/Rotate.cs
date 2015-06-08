using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public bool clockwise;
	public float angle;
	public float wait;
	private Coroutine coroutine;

	public void Start () {
		if (clockwise) { angle *= -1; }
	}

	public void Move () {
		coroutine = Coroutine.Make (RotateMovementCo ());
		coroutine.Start ();
	}

	public void Stop () {
		coroutine.KillCoroutine ();
	}
	
	public IEnumerator RotateMovementCo () {
		while (true) {
			transform.Rotate (Vector3.back, angle);
			yield return new WaitForSeconds (wait);
		}
	}
}