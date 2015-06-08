using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

public class BarrelAutoController : Controller {
	protected StateMachine<BarrelAutoController> barrelAutoMachine;

	public float lookTimeOffset;
	public bool lookAtTarget;

	public void Awake () {
		barrelAutoMachine = new StateMachine<BarrelAutoController> (this, new BarrelAutoEmpty ());
		barrelAutoMachine.AddState (new BarrelAutoFull ());
		barrelAutoMachine.AddState (new BarrelAutoFire ());
	}

    void Start () {}

	public void Update () {
		barrelAutoMachine.Update (Time.deltaTime);
	}
}