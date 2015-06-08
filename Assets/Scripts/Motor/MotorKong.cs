using UnityEngine;
using System.Collections;

public class MotorKong : Motor {
	public Vector2 velocity;
	private Rigidbody2D body;
	private float _speed;

	public float Speed {
		get { return _speed; }
		set { _speed = value; }
	}

	public void Awake () {
		body = GetComponent<Rigidbody2D> ();
		this.Speed = velocity.magnitude;
	}

	public override void Move () {
		body.AddForce (velocity, ForceMode2D.Impulse);
	}

	public void Move (Vector2 velocity) {
		velocity = velocity;
		Move ();
	}

	public void Follow (Vector2 position) {}
	
	public override void Stop () {
		body.velocity = Vector2.zero;
	}

	public IEnumerator MoveTo (Vector3 target) {
		while (true) {
			Vector2 currentPosition = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), 
			                     						   new Vector2 (target.x, target.y), Time.deltaTime);
			transform.position = Geometry.Vec3 (currentPosition);
			yield return 0;
		}
	}
}