using UnityEngine;
using System.Collections;

public class BarrelFullStop : BarrelFullRotateMove {

	public override void Begin() {
		if (_context.OnFireStopMovement) {
			motor.Stop ();
			rotor.Stop ();
		}
		_machine.ChangeState<BarrelFire> ();
	}
	
	public override void Update (float deltaTime) {}
	
	public override void End () {}
}
