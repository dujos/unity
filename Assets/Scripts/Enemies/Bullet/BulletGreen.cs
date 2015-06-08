using UnityEngine;
using System.Collections;

public class BulletGreen : Bullet {

	// Use this for initialization
	void Start () {
		motor = GetComponent<MotorStraight> ();
		motor.Move ();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
	}
}