using UnityEngine;
using System.Collections;

public class BarrelGhostEmpty : State<BarrelGhostController> {
	private bool barrelIsEmpty;
	private float temp;

	public override void Begin () {
		temp = 0;

		_context.onTriggerEnterEvent += OnTriggerEnter2D;
		_context.onTriggerExitEvent += OnTriggerExit2D;

		barrelIsEmpty = true;
	}
	
	public override void Update (float deltaTime) {
		if (temp < _context.wait) {
			temp += deltaTime;
		} else {
			_machine.ChangeState<BarrelGhostShow> ();
		}
	}
	
	public override void End () {}
	
	public virtual void OnTriggerEnter2D (Collider2D collider) {
		if (collider.name == "Kong") {
			if (barrelIsEmpty) {
				collider.GetComponent<KongController> ().GetMachine ().ChangeState<KongEnterBarrel> ();
				_machine.ChangeState<BarrelGhostFull> ();
			}
			barrelIsEmpty = false;
		}
	}

	public virtual void OnTriggerExit2D (Collider2D collider) {
		if (collider.name == "Kong") {
			barrelIsEmpty = true;
		}
	}
}