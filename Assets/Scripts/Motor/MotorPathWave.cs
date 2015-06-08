using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MotorPathWave : Motor {
	private int index;
	private List<Vector3> points;

	public GameObject pathMotor;
	public Vector2 velocity;
	public float wait;

	// Use this for initialization
	public void Start () {
		points = new List<Vector3> ();
		points.Insert (0, transform.position);
		List<Vector3> temp = pathMotor.GetComponent<Path>().Points;
		points.InsertRange (1, temp);

		Move ();
	}

	public void Move () {
		if (points.Count > 1) {
			StartCoroutine (MoveOnPath ());
		}
	}

	public IEnumerator MoveOnPath () {
		index = 1;
		Vector3 targetPosition = points[index];
		while (true) {
			transform.position =  Vector3.MoveTowards (transform.position, points[index], 
			                                           velocity.magnitude * Time.deltaTime);
			if (transform.position == targetPosition) {
				index++;
				index = index == -1 ? 0 : (index % (points.Count));
				if (index == 0) {
					index = 1;
					points.Reverse ();
				}
				targetPosition = points[index];
				yield return new WaitForSeconds (wait);
			}
			yield return 0;
		}
	}
}