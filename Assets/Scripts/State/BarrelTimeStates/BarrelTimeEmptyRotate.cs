using UnityEngine;
using System.Collections;

public class BarrelTimeEmptyRotate : BarrelEmptyRotate {
	protected Rotate rotate;

    public override void Begin() {
		//base.Begin ();
		if (_context.OnStartRotation) {
			rotate = _context.GetComponent<Rotate> ();
			rotate.enabled = true;
			rotate.Move ();
		}
	}
	
	public override void Update (float deltaTime) {}
    
    public override void End () {
		base.End ();
	}
}