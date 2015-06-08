using UnityEngine;
using System.Collections;

public class BarrelArrowFull : State<BarrelArrowController> {
	private bool shoot;
	private RotateWave wave;

	public override void Begin () {
		_context.onMouseButtonEvent += OnMouseDown;
		shoot = false;

		if (_context.GetComponent<RotateWave> ().enabled) {
			wave = _context.GetComponent<RotateWave> ();
			wave.Stop ();
		}

		if (_context.GetComponent<LookAtTarget> ().enabled) {
			LookAtTarget look = _context.GetComponent<LookAtTarget> ();
			if (_context.wait > 0) {
				look.LookAtWithDuration (_context.wait, ()=> { 
					shoot = true; 
				});
			} else {
				look.LookAt ();
				shoot = true;
			}
		} else if (_context.GetComponent<RotateBody> ().enabled) {
			_context.GetComponent<RotateBody> ().StartRotateBody ();
		}


		shoot = true;
	}
	
	public override void Update (float deltaTime) {}
	
	public override void End () {}

	public virtual void OnMouseDown () {
		if (shoot) {
			_machine.ChangeState<BarrelArrowFire> ();
			shoot = false;
		}
	}
}