using UnityEngine;
using System.Collections;

public class BulletPurple : Bullet {

	// Use this for initialization
	void Start () {
		motor = GetComponent<MotorTarget> ();
		motor.Move ();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
	}
}
