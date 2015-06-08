using UnityEngine;
using System.Collections;

public class BulletRed : Bullet {

	// Use this for initialization
	void Start () {
		motor = GetComponent<MotorCosinus> ();
		motor.Move ();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
	}
}
