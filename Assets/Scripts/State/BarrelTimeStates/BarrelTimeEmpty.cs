using UnityEngine;
using System.Collections;

public class BarrelTimeEmpty : BarrelEmpty {
	protected bool barrelIsEmpty;
	
	public override void Begin () {
		_context.onTriggerEnterEvent += OnTriggerEnter2D;
		_context.onTriggerExitEvent += OnTriggerExit2D;
		barrelIsEmpty = true;
	}
	
	public override void Update (float deltaTime) {}
	
	public override void End () {}
	
	public void OnTriggerEnter2D (Collider2D collider) {
		if (collider.name == "Kong") {
			if (barrelIsEmpty) {
				_machine.ChangeState<BarrelTimeFull> ();

				collider.GetComponent<KongController> ().GetMachine ().ChangeState<KongEnterBarrel> ();
				barrelIsEmpty = false;
			}
		}
	}
	
	public void OnTriggerExit2D (Collider2D collider) {
		if (collider.name == "Kong") {
			barrelIsEmpty = true;
		}
	}
}