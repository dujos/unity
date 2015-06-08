using UnityEngine;
using System.Collections;

public class RotateBody : MonoBehaviour {
	public float angle;

	void Start () {}

	public void StartRotateBody () {
		transform.Rotate (Vector3.back, angle);
	}

	public void StartRotateBody (float temp) {
		transform.Rotate (Vector3.back, temp);
	}
}