using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LookAtTarget : MonoBehaviour {
	public Transform target;

	public void Start () {}

	public void LookAt () {
		Vector3 relative = transform.InverseTransformPoint(target.position);
		float angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
		transform.Rotate(0, 0, -angle);
	}

	public void LookAtWithDuration (float duration, Action onComplete) {
		StartCoroutine (LookAtCo (duration, onComplete));
	}

	private IEnumerator LookAtCo (float duration, Action onComplete) {
		yield return new WaitForSeconds (duration);
		LookAt ();
		onComplete ();
	}
}