using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class BarrelFire : State<BarrelController> {
	private Coroutine coroutine;
	private KongController kong;

	public override void Begin() {
		kong = GameObject.Find ("Kong").GetComponent<KongController> ();

		kong.KongMotor.velocity = CalculateKongVelocity ();
		kong.GetMachine ().ChangeState<KongRun> ();

		if (_context.OnStartMovement) {
			_machine.ChangeState<BarrelEmptyMove> ();
		} else if (_context.OnStartRotation) {
			_machine.ChangeState<BarrelEmptyRotate> ();
		} else {
			_machine.ChangeState<BarrelEmpty> ();
		}
    }

	public override void Update (float deltaTime) {}

	public override void End () {
		if (_context.GetComponent<BarrelDestroy> ().enabled) {
			_context.GetComponent<BarrelDestroy> ().DestroyBarrel ();
		}

		if (!_context.OnEnterBarrelRotation && !_context.OnStartRotation) {
			if (_context.GetComponent<RotateBody> ().enabled) {
				float angle = _context.GetComponent<RotateBody> ().angle * (-1);
				_context.GetComponent<RotateBody> ().StartRotateBody (angle);
			}
		}
	}

	public Vector2 CalculateKongVelocity () {
		Vector2 velocity = Vector2.zero;
		if (_context.KongVelocity.magnitude > 0) {
			velocity = RotationBody.GetDirection (_context.transform) * _context.KongVelocity.magnitude;
		} else {
			velocity = RotationBody.GetDirection (_context.transform) * kong.KongSpeed;
		}
		return velocity;
	}

	public IEnumerator ResetRotationCo () {
		yield return new WaitForSeconds (_context.resetDuration);
		_context.transform.eulerAngles = new Vector3 (0f, 0f, _context.StartAngle);
	}

	public IEnumerator ResetBarrelCo () {
		_context.gameObject.SetActive (false);
		yield return new WaitForSeconds (_context.resetDuration);
		_context.gameObject.SetActive (true);
	}
}