using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class BarrelArrowFire : State<BarrelArrowController> {	
	private KongController kong;

	public override void Begin() {
		kong = GameObject.Find ("Kong").GetComponent<KongController> ();
		_context.onTriggerExitEvent += OnTriggerExit2D;

		kong.KongMotor.velocity = RotationBody.GetDirection (_context.transform) * _context.KongVelocity.magnitude;
		kong.GetMachine ().ChangeState<KongRun> ();
	}
	
	public override void Update (float deltaTime) {}
	
	public override void End () {}

	public void OnTriggerExit2D (Collider2D collider) {
		if (collider.name == "Kong") {
			_machine.ChangeState<BarrelArrowEmpty> ();

		}
	}
}