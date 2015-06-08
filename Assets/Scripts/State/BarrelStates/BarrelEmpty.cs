using UnityEngine;
using System.Collections;

public class BarrelEmpty : State<BarrelController> {
	protected bool barrelIsEmpty;

	public override void Begin () {
		_context.onTriggerEnterEvent += OnTriggerEnter2D;
		_context.onTriggerExitEvent += OnTriggerExit2D;
		barrelIsEmpty = true;
	}

	public override void Update (float deltaTime) {}

	public override void End () {}

	public virtual void OnTriggerEnter2D (Collider2D collider) {
		if (collider.name == "Kong") {
			if (barrelIsEmpty) {
				if (_context.OnEnterBarrelRotation || _context.OnStartRotation) {
					_machine.ChangeState<BarrelFullRotate> ();
				} else if (_context.OnEnterBarrelStartMovement || _context.OnStartMovement) {
					_machine.ChangeState<BarrelFullMove> ();
				} else {
					_machine.ChangeState<BarrelFull> ();
				}

				collider.GetComponent<KongController> ().GetMachine ().ChangeState<KongEnterBarrel> ();
				barrelIsEmpty = false;
			}
		}
	}

	public virtual void OnTriggerExit2D (Collider2D collider) {
		if (collider.name == "Kong") {
			barrelIsEmpty = true;
		}
	}
}