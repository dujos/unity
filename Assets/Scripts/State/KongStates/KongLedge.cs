using UnityEngine;
using System.Collections;

public class KongLedge : State<KongController> {
	private bool ledgeOn;

	public override void Begin () {
		ledgeOn = false;
		Ledge.OnKongAction += ()=> {
			_machine.ChangeState<KongFall> ();
		};
	}

	public override void Update (float deltaTime) {}

	public override void End () {
		_context.Body.gravityScale = 1f;
	}
}