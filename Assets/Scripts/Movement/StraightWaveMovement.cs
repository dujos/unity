using UnityEngine;
using System.Collections;

public class StraightWaveMovement : MonoBehaviour {

	public Vector3 start;
	public Vector3 target;
	public float duration;
	public float waitDuration;

	// Use this for initialization
	void Start () {
		if (waitDuration > 0) {
			StartCoroutine (MovementWithWaitCo ());
		} else {
			StartCoroutine (MovementCo ());
		}
	}

	public IEnumerator MovementCo () {
		var from = start;
		var to = target;

		while (true) {
			transform.position = Auto.Wave (duration, from, to);
			yield return 0;
		}
	}

	public IEnumerator MovementWithWaitCo () {
		var from = start;
		var to = target;
		
		while (true) {
			transform.position = Auto.Wave (duration, from, to);
			if (from == transform.position || to == transform.position) {
				yield return StartCoroutine(Auto.Wait(.5f));
			}
			yield return 0;
		}
	}
}