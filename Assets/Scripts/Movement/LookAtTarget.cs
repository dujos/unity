using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LookAtTarget : MonoBehaviour {
	public Transform point;

	// Use this for initialization
	void Start () {

	}
	
	private void TransformLookAt (Vector3 direction) {
		Quaternion rotation = Quaternion.LookRotation(direction, 
		     transform.TransformDirection(direction));
		transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
	}

	public void TransformLookAtTarget () {
		Quaternion rotation = Quaternion.LookRotation(transform.position - point.transform.position, 
			transform.TransformDirection(Vector3.forward));
		transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
	}

	public void TransformLookAtTargetWithDuration (float duration) {
		StartCoroutine (TransformLookAtTargetCo (duration));
	}

	private IEnumerator TransformLookAtTargetCo (float duration) {
		yield return new WaitForSeconds (duration);
		TransformLookAtTarget ();
	}
}