using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider2D))]
public class BarrelTimeController : BarrelController {
	public float shootCountdown;

	public void Awake () {
		base.Awake ();
		barrelMachine.AddState (new BarrelTimeEmpty ());
		barrelMachine.AddState (new BarrelTimeEmptyMove ());
		barrelMachine.AddState (new BarrelTimeEmptyRotate ());
		barrelMachine.AddState (new BarrelTimeEmptyRotateMove ());

		barrelMachine.AddState (new BarrelTimeFull ());

		barrelMachine.AddState (new BarrelTimeFire ());

		/*

		barrelTimeMachine.AddState (new BarrelTimeFull ());
		barrelTimeMachine.AddState (new BarrelTimeFullMove ());
		barrelTimeMachine.AddState (new BarrelTimeFullRotate ());		

		barrelTimeMachine.AddState (new BarrelTimeFullStopMove ());
		barrelTimeMachine.AddState (new BarrelTimeFullStopRotate ());
		*/
	}
	
	public void Start () {
		base.Start ();
		barrelMachine.ChangeState<BarrelTimeEmpty> ();
	}
	
	public void Update () {
		barrelMachine.Update (Time.deltaTime);
	}
}
