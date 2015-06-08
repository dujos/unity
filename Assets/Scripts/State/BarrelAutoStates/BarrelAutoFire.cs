﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class BarrelAutoFire : State<BarrelAutoController> {	
	private KongController kong;
	
	public override void Begin() {
		kong = GameObject.Find ("Kong").GetComponent<KongController> ();
		kong.KongMotor.velocity = _context.KongVelocity.magnitude * RotationBody.GetDirection (_context.transform);

		Debug.Log (kong.KongMotor.velocity);

		kong.GetMachine ().ChangeState<KongRun> ();
		_machine.ChangeState<BarrelAutoEmpty> ();
	}
	
	public override void Update (float deltaTime) {}
	
	public override void End () {}
	
	public Vector2 CalculateKongVelocity () {
		Vector2 velocity = Vector2.zero;
		if (_context.KongVelocity.magnitude > 0) {
			velocity = RotationBody.GetDirection (_context.transform) * _context.KongVelocity.magnitude;
		} else {
			velocity = RotationBody.GetDirection (_context.transform) * kong.KongSpeed;
		}
		return velocity;
	}
}