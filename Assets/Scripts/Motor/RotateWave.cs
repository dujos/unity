using UnityEngine;
using System.Collections;

public class RotateWave : MonoBehaviour {
	public bool clockwise;
	public float duration;
	public float angle;

	private Coroutine coroutine;
	public Vector3 from;
	public Vector3 to;
	
	public void Start () {
		if (clockwise) { 
			angle *= -1; 
		}
	}

	public void Move () {
		coroutine = Coroutine.Make (RotateWaveMovementCo ());
		coroutine.Start ();
	}
	
	public void Stop () {
		coroutine.KillCoroutine ();
	}

	public IEnumerator RotateWaveMovementCo () {
		while (true) {
			transform.Rotate (Vector3.back, angle);
			float offset = RotationBody.GetAngle (transform);
			if (offset.Equals (to.z) || offset.Equals (from.z)) {
				angle *= -1;
			}
			yield return new WaitForSeconds (duration);
		}
	}
}