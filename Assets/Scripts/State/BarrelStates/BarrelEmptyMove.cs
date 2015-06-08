using UnityEngine;
using System.Collections;

public class BarrelEmptyMove : BarrelEmpty {
	private bool barrelIsEmpty;
	private Motor motor;
	
	public override void Begin () {
		base.Begin ();

		if (_context.OnStartMovement) {
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
	
	public override void Update (float deltaTime) {}

	
	public override void End () {
		base.End ();
	}
}
