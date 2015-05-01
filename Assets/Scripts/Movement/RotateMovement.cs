using UnityEngine;
using System.Collections;

public class RotateMovement : MonoBehaviour {
	public float angle;
	public bool wave;
	public float duration;

	public Vector3 fromRotation;
	public Vector3 toRotation;

	public void Start () {
		if (wave) {
			StartCoroutine (RotateWaveMovementCo ());
		} else {
			StartCoroutine (RotateMovementCo ());
		}
	}

	public void Update () {

	}
	
	public IEnumerator RotateMovementCo () {
		while (true) {
			transform.Rotate (Vector3.back, angle);
			yield return new WaitForSeconds (duration);
		}
	}

	public IEnumerator RotateWaveMovementCo () {

		while (true) {
			if (fromRotation.z < toRotation.z) {
				angle *= -1;
			} 

			transform.Rotate (Vector3.back, angle);
			yield return new WaitForSeconds (1f);

			float temp = Mathf.Round(transform.eulerAngles.z*10)/10;

			if (temp >= fromRotation.z) {
				angle *= -1;
			} else if (temp <= toRotation.z) {
				angle *= -1;
			}
		}
	}
}