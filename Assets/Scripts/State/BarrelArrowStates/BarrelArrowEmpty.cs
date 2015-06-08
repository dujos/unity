using UnityEngine;
using System.Collections;

public class BarrelArrowEmpty : State<BarrelArrowController> {
	private bool barrelIsEmpty;
	private RotateWave wave;

	public override void Begin () {
		_context.onTriggerEnterEvent += OnTriggerEnter2D;
		barrelIsEmpty = true;

		if (_context.GetComponent<RotateWave> ().enabled) {
			wave = _context.GetComponent<RotateWave> ();
			wave.Move ();
		}
	}
	
	public override void Update (float deltaTime) {}
	
	public override void End () {
		GameObject.Find ("Kong").GetComponent<KongController> ().transform.position = _context.transform.position;
	}
	
	public void OnTriggerEnter2D (Collider2D collider) {
		if (collider.name == "Kong") {
			if (barrelIsEmpty) {
				collider.GetComponent<KongController> ().GetMachine ().ChangeState<KongEnterBarrel> ();
				_machine.ChangeState<BarrelArrowFull> ();
				barrelIsEmpty = false;
			}
		}
	}
}