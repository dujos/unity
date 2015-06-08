using UnityEngine;
using System.Collections;

public class BarrelFullStopRotate : BarrelFullRotate {

	public override void Begin() {
		Debug.Log ("777");
		rotate = _context.GetComponent<Rotate> ();
		rotate.Stop ();
		_machine.ChangeState<BarrelFire> ();
	}
	
	public override void Update (float deltaTime) {}
	
	public override void End () {}
}
