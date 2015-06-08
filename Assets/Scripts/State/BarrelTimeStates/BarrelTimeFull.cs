using UnityEngine;
using System.Collections;

public class BarrelTimeFull : BarrelFull {
	protected bool isKongInside;
	private KongController kong;
	private float timer;
	public float countdown = 5f;

	public override void Begin() {
		isKongInside = true;
		_context.onMouseButtonEvent += OnMouseDown;

		kong = GameObject.Find ("Kong").GetComponent<KongController> ();
		kong.SetKongPosition (_context.transform);
	}

	public override void Update (float deltaTime) {
		base.Update (deltaTime);

		timer += deltaTime;
		if (timer > countdown) {
			_machine.ChangeState<BarrelTimeFire> ();
			timer = 0;
		}
	}
	
	public override void End () {
		base.End ();
	}

	public override void OnMouseDown () {
		if (isKongInside) {
			_machine.ChangeState<BarrelTimeFire> ();
		}
	}
}