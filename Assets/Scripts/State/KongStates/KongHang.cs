using UnityEngine;
using System.Collections;

public class KongHang : State<KongController> {

	public override void Begin () {
		_context.GetComponent<MotorKong> ().Stop ();
		_context.Body.gravityScale = 0f;
		_context.SetKongPosition (_context.CurrentPosition);

		_context.onMouseButtonEvent += OnMouseDown;
	}

	public override void Update (float deltaTime) {}

	public override void End () {
		_context.Body.gravityScale = 1f;
	}

	public void OnMouseDown () {
		_machine.ChangeState<KongFall> ();
	}
}
