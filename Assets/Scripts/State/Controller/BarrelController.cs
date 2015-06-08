using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(BoxCollider2D))]
public class BarrelController : Controller {
	protected StateMachine<BarrelController> barrelMachine;

	private float _startAngle;
	public float resetDuration;

	public bool _onEnterBarrelRotation;
	public bool _onStartRotation;

	public bool _onEnterBarrelStartMovement;
	public bool _onStartMovement;

	public bool _onFireStopMovement;

	public enum MotorMovement { NoMotor = 0, MotorStraightWaveMove = 1, MotorParallelMove = 2, MotorPathMove = 3 }
	public MotorMovement motorMovement;
	
	public bool OnEnterBarrelRotation {
		get { return _onEnterBarrelRotation; }
		set { _onEnterBarrelRotation = value; }
	}

	public bool OnStartRotation {
		get { return _onStartRotation; }
		set { _onStartRotation = value; }
	}

	public bool OnEnterBarrelStartMovement {
		get { return _onEnterBarrelStartMovement; }
		set { _onEnterBarrelStartMovement = value; }
	}

	public bool OnStartMovement {
		get { return _onStartMovement; }
		set { _onStartMovement = value; }
	}

	public bool OnFireStopMovement {
		get { return _onFireStopMovement; }
		set { _onFireStopMovement = value; }
	}

	public float StartAngle {
		get { return _startAngle; }
		set { _startAngle = value; }
	}

	public void Awake () {
		barrelMachine = new StateMachine<BarrelController> (this, new BarrelEmpty ());
		barrelMachine.AddState (new BarrelEmptyMove ());
		barrelMachine.AddState (new BarrelEmptyRotate ());
		barrelMachine.AddState (new BarrelEmptyRotateMove ());

		barrelMachine.AddState (new BarrelFull ());
		barrelMachine.AddState (new BarrelFullMove ());
		barrelMachine.AddState (new BarrelFullRotate ());

		barrelMachine.AddState (new BarrelFire ());

		barrelMachine.AddState (new BarrelFullStopMove ());
		barrelMachine.AddState (new BarrelFullStopRotate ());
	}

    public void Start () {
		StartAngle = transform.rotation.eulerAngles.z;

		if (_onStartMovement) {
			if (_onStartRotation) {
				barrelMachine.ChangeState<BarrelEmptyRotateMove> ();
			} else {
				barrelMachine.ChangeState<BarrelEmptyMove> ();
			}
		} else {
			if (_onStartRotation) {
				barrelMachine.ChangeState<BarrelEmptyRotate> ();
			} else {
				barrelMachine.ChangeState<BarrelEmpty> ();
			}
		}
	}

	public void Update () {
		barrelMachine.Update (Time.deltaTime);
	}
}