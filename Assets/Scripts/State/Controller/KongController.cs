using UnityEngine;

using System;
using System.Collections;

public class KongController : Controller {
	protected StateMachine<KongController> machine;

	protected bool isFacingRight;
	public float waitToDestroy;

	protected MotorKong _kongMotor;
	protected float _kongSpeed;
	
	public MotorKong KongMotor {
		get { return _kongMotor; }
		set { _kongMotor = value; }
	}

	public float KongSpeed {
		get { return _kongSpeed; }
		set { _kongSpeed = value; }
	}

	void Start () {
		KongMotor = GetComponent<MotorKong> ();
		KongSpeed = KongMotor.velocity.magnitude;
		isFacingRight = true;

		SetupKongStates ();
	}

	private void SetupKongStates () {
		machine = new StateMachine<KongController> (this, new KongRun ());
		machine.AddState (new KongHang ());
		machine.AddState (new KongFall ());
		machine.AddState (new KongEnterBarrel ());
		machine.AddState (new KongDie ());
		machine.AddState (new KongLedge ());
	}

	public void Update () {
		machine.Update (Time.deltaTime);
	}

	public StateMachine<KongController> GetMachine () {
		return machine;
	}

	private void KongCheckFlip (float x) {
		if (isFacingRight) {
			if (x < 0) {
				KongFlip (false);
			}
		} else {
			if (x > 0) {
				KongFlip (true);
			}
		}
	}
	
	private void KongFlip (bool flip) {
		transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		isFacingRight = flip;
	}
	
	public void SetKongDirection (Transform target) {
		SetKongDirection (new Vector2 (target.position.x, target.position.y));
	}
	
	public void SetKongDirection (Vector2 direction) {
		KongCheckFlip (direction.x);
		float speed = KongVelocity.magnitude;
		KongVelocity = direction * speed;
    }

	public void SetKongPosition (Transform target) {
		SetKongPosition (new Vector2 (target.position.x, target.position.y));
    }
    
	public void SetKongPosition (Vector2 position) {
		Body.MovePosition (position);
    }
	    
	public Vector2 GetKongDirection () {
		return Body.velocity.normalized;
	}
}