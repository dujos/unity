using UnityEngine;
using System.Collections;

public class BarrelGhostShow : State<BarrelGhostController> {
	private float temp;

	public override void Begin () {
		temp = 0;

		_context.GetComponent<SpriteRenderer> ().enabled = false;
	}
	
	public override void Update (float deltaTime) {
		if (temp < _context.wait) {
			temp += deltaTime;
		} else {
			_machine.ChangeState<BarrelGhostEmpty> ();
		}
	}
	
	public override void End () {
		_context.GetComponent<SpriteRenderer> ().enabled = true;
	}
}