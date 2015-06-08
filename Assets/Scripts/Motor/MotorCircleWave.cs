using UnityEngine;
using System.Collections;

public class MotorCircleWave : Motor {
	public int angle;
	public float speed;
	public bool clockwise;
	public float wait;
	public Transform center;

	public float offset;
	private float target;
	private float source;

	// Use this for initialization
	public void Start () {
		source = CalculateAngle ();
		target = source + offset >= 360 ? 0 : source + offset;
		Move ();
	}

	public void Update () {}
	
	public override void Move () {
		StartCoroutine (MoveCo ());
	}
	
	public IEnumerator MoveCo () {
		if (clockwise) {
			speed = speed * (-1);
		}

		while (true) {
			transform.RotateAround (center.position, Vector3.back, speed * Time.deltaTime);
			transform.rotation = Quaternion.identity;

			angle = CalculateAngle ();
			if (angle != -1) {
				if (target == angle || source == angle) {
					speed = speed * (-1);
					yield return new WaitForSeconds (wait);
				}
			}
			yield return 0;
		}
	}

	private int CalculateAngle () {
		Vector2 direction = (transform.position - center.position).normalized;
		
		float x = (float) System.Math.Round (direction.x, 1);
		float y = (float) System.Math.Round (direction.y, 1);

		var tempAngle = RotationBody.GetFixedAngle (new Vector2 (x, y));
		return tempAngle;
	}

	private int CalculateAngle (Vector3 direction) {
		return RotationBody.GetFixedAngle (new Vector2 (direction.x, direction.y));
	}
}