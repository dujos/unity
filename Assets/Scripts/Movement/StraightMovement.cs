using UnityEngine;
using System.Collections;

public class StraightMovement : MonoBehaviour {
	public Transform start;
	public Transform target;
	public bool limited;

	private float speed;
	private Vector3 direction;
	
	// Use this for initialization
	void Start () {
		speed = 5;
		direction = (target.position - start.position).normalized;
	}

	public void Update () {
		if (limited) {
			transform.position = Vector3.MoveTowards (start.position, target.position, Time.fixedDeltaTime * speed);
		} else {
			transform.position += direction * Time.fixedDeltaTime * speed;
		}

		Debug.DrawLine(start.position, transform.position, Color.white, 100);
	}
}