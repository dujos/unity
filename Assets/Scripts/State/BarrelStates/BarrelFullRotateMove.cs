using UnityEngine;
using System.Collections;

public class BarrelFullRotateMove : BarrelFull {
	protected Rotate rotor;
	protected Motor motor;
	
	public override void Begin() {
		base.Begin ();
		rotor = _context.GetComponent<Rotate> ();
		motor = _context.GetComponent<MotorStraightWave> ();

		if (motor != null || rotor != null) {
			motor.enabled = true;
			motor.Move ();

			rotor.enabled = true;
			rotor.Move ();
		}
	}
	
	public override void Update (float deltaTime) {
		base.Update (deltaTime);
	}
	
	public override void End () {
		base.End ();
	}

	public override void OnMouseDown () {
		if (isKongInside) {
			if (_context.OnFireStopMovement) {
				_machine.ChangeState<BarrelFullStop> ();
			} else {
				_machine.ChangeState<BarrelFire> ();
			}
		}
	}
}