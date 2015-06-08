using UnityEngine;
using System.Collections;

public class KongRun : State<KongController> {
	private bool barrelIsEmpty;

	public override void Begin () {
		_context.onTriggerEnterEvent += OnTriggerEnter2D;
		_context.onTriggerExitEvent += OnTriggerExit2D;

		_context.onCollisionEnterEvent += OnCollisionEnter2D;
		//_context.onCollisionExitEvent += OnCollisionExit2D;

		Hook.OnKongAction += OnHookDetected;
		Ledge.OnKongAction += OnLedgeDetected;
		barrelIsEmpty = true;

		_context.Body.gravityScale = 0.5f;
		_context.GetComponent<MotorKong> ().Move ();
	}

	public override void Update (float deltaTime) {}

	public override void End () {}

	public void OnTriggerEnter2D (Collider2D collider) {
		if (collider.name == "Barrel" || 
		    collider.name == "BarrelArrow" || 
		    collider.name == "BarrelAuto") {
			if (barrelIsEmpty) {
				//_machine.ChangeState<KongEnterBarrel> ();
				barrelIsEmpty = false;

			}
		} else if (collider.name == "Platform") {
			_context.GetComponent<MotorKong> ().Stop ();
			Vector2 velocity = _context.GetComponent<MotorKong> ().velocity;
			Vector2 direction = RotationBody.GetDirection (collider.transform).normalized;
			
			_context.KongMotor.velocity = direction * velocity.magnitude;
			_context.KongMotor.Move ();

		} else if (collider.name == "kronky") {
			_context.GetComponent<MotorKong> ().Stop ();
			Vector2 velocity = collider.GetComponent<Kronky> ().KongVelocity;
			
			_context.KongMotor.velocity = velocity;
			_context.KongMotor.Move ();
		}
	}
	
	public void OnTriggerExit2D (Collider2D collider) {
		if (collider.name == "Barrel" || 
		    collider.name == "BarrelArrow" || 
		    collider.name == "BarrelAuto") {
			barrelIsEmpty = true;
		}
	}

	public void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.name == "BarrelSwitch") {
			Vector2 velocity = _context.KongMotor.velocity;
			_context.KongMotor.Stop ();
			_context.KongMotor.Move (velocity.magnitude * collision.contacts[0].normal);
		}
	}

	public void OnLedgeDetected () {
		_machine.ChangeState<KongLedge> ();
	}

	public void OnHookDetected (Vector2 position) {
		_context.CurrentPosition = position;
		_machine.ChangeState<KongHang> ();
	}
}