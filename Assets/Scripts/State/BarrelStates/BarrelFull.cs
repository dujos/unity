using UnityEngine;
using System.Collections;

public class BarrelFull : State<BarrelController> {
	protected bool isKongInside;
	private KongController kong;
	
	public override void Begin() {
		isKongInside = true;
		_context.onMouseButtonEvent += OnMouseDown;

		kong = GameObject.Find ("Kong").GetComponent<KongController> ();
		kong.SetKongPosition (_context.transform);

		if (!_context.OnEnterBarrelRotation && !_context.OnStartRotation) {
			if (_context.GetComponent<RotateBody> ().enabled) {
				_context.GetComponent<RotateBody> ().StartRotateBody ();
			}
		}
	}
	
	public override void Update (float deltaTime) {
		if (isKongInside) {
			kong.Body.position = _context.GetComponent<Rigidbody2D> ().position;
		}
    }
    
    public override void End () {
		isKongInside = false;
	}

	public virtual void OnMouseDown () {
		if (isKongInside) {
			_machine.ChangeState<BarrelFire> ();
		}
    }
}