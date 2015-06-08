using UnityEngine;
using System.Collections;

public class BarrelFullMove : BarrelFull {
	private KongController kong;
	protected Motor motor;

	public override void Begin() {
		base.Begin ();
	
		if (!_context.OnStartMovement) {
			if (_context.motorMovement == BarrelController.MotorMovement.MotorStraightWaveMove) {
				motor = _context.GetComponent<MotorStraightWave> ();
			} else if (_context.motorMovement == BarrelController.MotorMovement.MotorParallelMove) {
				motor = _context.GetComponent<MotorParallelWave> ();
			} else if (_context.motorMovement == BarrelController.MotorMovement.MotorPathMove) {
				motor = _context.GetComponent<MotorPath> ();
			}
			
			if (motor != null) {
				motor.enabled = true;
				motor.Move ();
			}
		}
	}
	
	public override void Update (float deltaTime) {
		base.Update (deltaTime);
	}
	
	public override void End () {
		isKongInside = false;
	}

	public override void OnMouseDown () {
		if (isKongInside) {
			if (_context.OnFireStopMovement) {
				_machine.ChangeState<BarrelFullStopMove> ();
			} else {
				_machine.ChangeState<BarrelFire> ();
			}
		}
	}
}