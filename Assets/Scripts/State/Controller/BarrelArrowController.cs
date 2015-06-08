using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(BoxCollider2D))]
public class BarrelArrowController : Controller {
	protected StateMachine<BarrelArrowController> barrelArrowMachine;

	protected bool _waveRotate;
	public float wait;

	public bool WaveRotate {
		get { return _waveRotate; }
		set { _waveRotate = value; }
	}
	
	public void Awake () {
		/*
		if (GetComponent<LookAtTarget> ().enabled) {
			_waveRotate = false;
		} else if (GetComponent<RotateWave> ().enabled) {
			_waveRotate = true;
		}
		*/
	}
	
	void Start () {
		barrelArrowMachine = new StateMachine<BarrelArrowController> (this, new BarrelArrowEmpty ());
		barrelArrowMachine.AddState (new BarrelArrowFull ());
		barrelArrowMachine.AddState (new BarrelArrowFire ());
	}
	
	public void Update () {
		barrelArrowMachine.Update (Time.deltaTime);
	}
}