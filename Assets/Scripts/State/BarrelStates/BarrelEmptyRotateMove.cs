using UnityEngine;
using System.Collections;

public class BarrelEmptyRotateMove : BarrelEmpty {
	protected Rotate rotate;
	protected Motor motor;
	
	public override void Begin() {
		base.Begin ();

		rotate = _context.GetComponent<Rotate> ();
		rotate.enabled = true;
		rotate.Move ();

		if (_context.motorMovement == BarrelController.MotorMovement.MotorStraightWaveMove) {
			motor = _context.GetComponent<MotorStraightWave> ();
		} else if (_context.motorMovement == BarrelController.MotorMovement.MotorParallelMove) {
			//motor = _context.GetComponent<MotorParallelWave> ();
		} else if (_context.motorMovement == BarrelController.MotorMovement.MotorPathMove) {
			//motor = _context.GetComponent<MotorPath> ();
		}

		if (motor != null) {
			motor.enabled = true;
			motor.Move ();
		}
	}
	
	public override void Update (float deltaTime) {}
	
	public override void End () {
		base.End ();
	}

	public override void OnTriggerEnter2D (Collider2D collider) {
		if (collider.name == "Kong") {
			if (barrelIsEmpty) {
				_machine.ChangeState<BarrelFullRotateMove> ();

				collider.GetComponent<KongController> ().GetMachine ().ChangeState<KongEnterBarrel> ();
				barrelIsEmpty = false;
			}
		}
	}
}