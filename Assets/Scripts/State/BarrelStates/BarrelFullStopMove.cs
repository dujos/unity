using UnityEngine;
using System.Collections;

public class BarrelFullStopMove : BarrelFullMove {

	public override void Begin() {
		if (_context.motorMovement == BarrelController.MotorMovement.MotorStraightWaveMove) {
			motor = _context.GetComponent<MotorStraightWave> ();
		} else if (_context.motorMovement == BarrelController.MotorMovement.MotorParallelMove) {
		} else if (_context.motorMovement == BarrelController.MotorMovement.MotorPathMove) {
		}

		motor.Stop ();
		_machine.ChangeState<BarrelFire> ();
	}
	
	public override void Update (float deltaTime) {}
	
	public override void End () {}
}