using UnityEngine;
using System.Collections;

public class BarrelFullRotate : BarrelFull {
	protected Rotate rotate;
	
	public override void Begin() {
		base.Begin ();

		if (!_context.OnStartRotation) {
			rotate = _context.GetComponent<Rotate> ();
			rotate.enabled = true;
			rotate.Move ();
		}
    }
	
	public override void Update (float deltaTime) {}
    
    public override void End () {
		isKongInside = false;
	}

	public override void OnMouseDown () {
		if (isKongInside) {
			if (_context.OnFireStopMovement) {
				_machine.ChangeState<BarrelFullStopRotate> ();
			} else {
				_machine.ChangeState<BarrelFire> ();
			}
		}
	}
}