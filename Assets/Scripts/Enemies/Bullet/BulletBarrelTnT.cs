using UnityEngine;
using System.Collections;
using System.IO;

public class BulletBarrelTnT : Bullet {
	//protected Detector detector;
	//private MotorStraight motor;
	//public enum MotorMovement { NoMotor = 0, MotorStraight = 1 }
	//public MotorMovement motorMovement;

	public void Awake () {}

	public void Start () {
		base.Start ();

		/*
		if (MotorMovement.MotorStraight == motorMovement) {
			motor = GetComponent<MotorStraight> ();
			motor.Move ();
		}
		*/
	}
}