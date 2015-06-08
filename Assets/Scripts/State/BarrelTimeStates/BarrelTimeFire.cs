using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class BarrelTimeFire : BarrelFire {
	private Coroutine coroutine;
	private KongController kong;
	
	public override void Begin() {
		kong = GameObject.Find ("Kong").GetComponent<KongController> ();

		kong.KongMotor.velocity = new Vector2 (0, 8);
		kong.GetMachine ().ChangeState<KongRun> ();
	}
	
	public override void Update (float deltaTime) {
		base.Update (deltaTime);
	}
	
	public override void End () {
		base.End ();
	}
}