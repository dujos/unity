using UnityEngine;
using System.Collections;

public class MotorFollow : Motor {
	public Transform target;
	public float smoothDampTime = 0.2f;
	public Vector3 cameraOffset;
	private Vector3 _smoothDampVelocity;

	public void Start () {
		Move ();
	}
	
	public void Move () {
		StartCoroutine (MoveOnPath ());
	}

	public IEnumerator MoveOnPath () {
		transform.position = Vector3.SmoothDamp (transform.position, target.position - cameraOffset, 
		                                         ref _smoothDampVelocity, smoothDampTime);
		yield return 0;
	}
}