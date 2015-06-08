using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletIce : Bullet {	

	public void Start () {
		motor = GetComponent<MotorStraight> ();
		motor.Move ();
	}
	
	public void Update () {
		base.Update ();
	}
}