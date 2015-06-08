using UnityEngine;
using System.Collections;

public class BarrelAutoFull : State<BarrelAutoController> {
	protected bool isKongInside;
	private KongController kong;
	private LookAtTarget look;
	
	public override void Begin() {
		Debug.Log ("Begin " + _machine.GetCurrentStateName ());

		kong = GameObject.Find ("Kong").GetComponent<KongController> ();
		kong.SetKongPosition (_context.transform);

		if (_context.lookAtTarget) {
			look = _context.GetComponent<LookAtTarget> ();
			look.enabled = true;

			if (_context.lookTimeOffset > 0) {
				look.LookAtWithDuration (_context.lookTimeOffset, () => {
					_machine.ChangeState<BarrelAutoFire> ();
				});
			} else {
				look.LookAt ();
				_machine.ChangeState<BarrelAutoFire> ();
			}
		}

		_machine.ChangeState<BarrelAutoFire> ();
	}
	
	public override void Update (float deltaTime) {
		//kong.Body.position = _context.GetComponent<Rigidbody2D> ().position;
	}
	
	public override void End () {}
}