using UnityEngine;
using System.Collections;

public class BarrelGhostFull : State<BarrelGhostController> {
	protected bool isKongInside;
	private KongController kong;
	private LookAtTarget look;
	
	public override void Begin() {
		kong = GameObject.Find ("Kong").GetComponent<KongController> ();
		kong.SetKongPosition (_context.transform);

		if (_context.lookAt) {
			LookAtTarget look = _context.GetComponent<LookAtTarget> ();
			if (_context.wait > 0) {
				look.LookAtWithDuration (_context.wait, ()=> {
					_machine.ChangeState<BarrelGhostFire> ();
				});
			} else {
				look.LookAt ();
				_machine.ChangeState<BarrelGhostFire> ();
			}
		}
	}
	
	public override void Update (float deltaTime) {}
	
	public override void End () {}
}