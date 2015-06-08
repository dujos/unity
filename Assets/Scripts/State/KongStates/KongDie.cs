using UnityEngine;
using System.Collections;

public class KongDie : State<KongController> {

	public override void Begin() {
		if (_context.waitToDestroy > 0) {
			_context.Invoke ("ActivateDestroyKong", _context.waitToDestroy);
		} else {
			_context.Invoke ("ActivateDestroyKong", 0);
		}
	}
	
	public override void Update (float deltaTime) {}
	
	public override void End () {}

	public void ActivateDestroyKong () {}
}