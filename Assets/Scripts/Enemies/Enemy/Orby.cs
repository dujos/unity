using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Orby : MonoBehaviour {
	
	private Vector2 _orbyVelocity;
	private MotorEnemy motor;

	public Vector2 OrbyVelocity {
		get { return _orbyVelocity; }
		set { _orbyVelocity = value; }
	}
	
	public void Awake () {}
	
	public void Start () {
		motor = GetComponent<MotorEnemy> ();
		motor.Move ();
	}
	
	public void OnTriggerEnter2D (Collider2D collider) {
        if (collider.name == "Platform") {
			motor.Stop ();
			OrbyVelocity = motor.velocity;
			Vector2 direction = RotationBody.GetDirection (collider.transform).normalized;

			motor.velocity = direction * OrbyVelocity.magnitude;
			motor.Move ();
        }	
	}
}