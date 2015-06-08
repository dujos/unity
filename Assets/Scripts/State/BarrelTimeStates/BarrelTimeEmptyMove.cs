using UnityEngine;
using System.Collections;

public class BarrelTimeEmptyMove : BarrelTimeEmpty {
	private bool barrelIsEmpty;
	private Motor motor;

	public override void Begin () {
		base.Begin ();
	}
	
	public override void Update (float deltaTime) {}

	public override void End () {
		base.End ();
	}
}
