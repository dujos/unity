using UnityEngine;
using System.Collections;

public class SinusMovement : MonoBehaviour {

	public Transform destination;
	
	private float angle;
	private float speed;
	private float amplitude;

	// Use this for initialization
	void Start () {
		angle = 0;
		speed = 3;
		amplitude = 2f;
	}
	
	// Update is called once per frame
	void Update () {
		angle += Time.fixedDeltaTime * speed;
		if (angle > 360) {
			angle = 0;
		}
		
		Vector3 delta = new Vector3 (Mathf.Sin (angle), Mathf.Cos (angle), 0) * amplitude;
		Vector3 direction = (destination.position - transform.position).normalized;
		transform.position += (delta + direction) * Time.fixedDeltaTime * speed;

		Debug.DrawLine(destination.position, transform.position, Color.white, 100);
	}
}
