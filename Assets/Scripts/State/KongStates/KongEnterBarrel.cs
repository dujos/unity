using UnityEngine;
using System.Collections;

public class KongEnterBarrel : State<KongController> {

	public override void Begin() {
		_context.Body.gravityScale = 0;
		_context.GetComponent<MotorKong> ().Stop ();
	}

	public override void Update (float deltaTime) {}

	public override void End () {}
}
