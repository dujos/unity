using UnityEngine;
using System.Collections;

public class BarrelAutoEmpty : State<BarrelAutoController> {
	private bool barrelIsEmpty;
	
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
				collider.GetComponent<KongController> ().GetMachine ().ChangeState<KongEnterBarrel> ();
				_machine.ChangeState<BarrelAutoFull> ();
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