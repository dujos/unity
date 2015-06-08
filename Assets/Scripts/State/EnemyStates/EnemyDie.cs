using UnityEngine;
using System.Collections;

public class EnemyDie : State<EnemyController> {
	private bool die = false;

	public void OnTriggerEnter2D (Collider2D collider) {
		if (collider.name == "Kong") {
			die = true;
		}
	}

	public override void Begin() {
		Debug.Log ("Enemy Die Begin");
	}

	public override void Update (float deltaTime) {

	}
	
	public override void End () {
		Debug.Log ("Enemy Die End");
	}
}
