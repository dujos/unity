using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MotorPath : Motor {
	private int index;
	private List<Vector3> points;
	
	public GameObject pathMotor;
	public Vector2 velocity;
	public float wait;
	private Coroutine coroutine;

	public void Awake () {
		points = new List<Vector3> ();
		points.Insert (0, transform.position);
		List<Vector3> temp = pathMotor.GetComponent<Path> ().Points;
		points.InsertRange (1, temp);
	}

	// Use this for initialization
	public void Start () {
		index = 1;
	}

	public override void Move () {
		if (points.Count > 1) {
			coroutine = Coroutine.Make (MoveOnPath ());
			coroutine.Start ();
		}
	}

	public override void Stop () {
		coroutine.KillCoroutine ();
	}

	public IEnumerator MoveOnPath () {
		Vector3 targetPosition = points[index];
		while (true) {
			transform.position = 
				Vector3.MoveTowards (transform.position, points[index], velocity.magnitude * Time.deltaTime);

			if (transform.position == targetPosition) {
				index++;
				index = index == -1 ? 0 : (index % (points.Count));

				if (index == 0) {
					Stop ();
				}

				targetPosition = points[index];
				yield return new WaitForSeconds (wait);
			}
			yield return 0;
		}
	}
}