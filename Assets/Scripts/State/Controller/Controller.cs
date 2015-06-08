using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(Rigidbody2D))]
public class Controller : MonoBehaviour {
	public event Action onMouseButtonEvent;

	public event Action<Collider2D> onTriggerEnterEvent;
	public event Action<Collider2D> onTriggerExitEvent;

	public event Action<Collision2D> onCollisionEnterEvent;
	public event Action<Collision2D> onCollisionExitEvent;

	protected Animation _animation;
	protected Animator _animator;
	protected Rigidbody2D _body;

	protected Vector2 _currentPosition;
	public Vector2 _kongVelocity;
    
	public Vector2 KongVelocity {
		get { return _kongVelocity; }
		set { _kongVelocity = value; }
	}
	
	public Vector2 CurrentPosition {
		get { return _currentPosition; }
		set { _currentPosition = value; }
	}

	public Animation Animation {
		get { return _animation; }
		set { _animation = value; }
	} 
	
	public Animator Animator {
		get { return _animator; }
		set { _animator = value; }
	}
	
	public Rigidbody2D Body {
		get { return _body; }
		set { _body = value; }
	}

	public void Awake () {
		Body = GetComponent<Rigidbody2D> ();
		Animator = GetComponent<Animator> ();
		Animation = GetComponent<Animation> ();
		CurrentPosition = new Vector2 (transform.position.x, transform.position.y);
	}

	// Use this for initialization
	void Start () {}
	
	public IEnumerator PlayAnimation (string animation, Action onComplete) {
		_animation.Play (animation);
		while (_animation.IsPlaying (animation)) {
			yield return 0;
		}
		onComplete ();
	}

	public void OnTriggerEnter2D (Collider2D col) {
		if (onTriggerEnterEvent != null) {
			onTriggerEnterEvent (col);
		}
	}
	
	public void OnTriggerExit2D (Collider2D col) {
		if (onTriggerExitEvent != null) {
			onTriggerExitEvent (col);
		}
	}

	public void OnCollisionEnter2D (Collision2D col) {
		if (onCollisionEnterEvent != null) {
			onCollisionEnterEvent (col);
		}
	}
	
	public void OnCollisionExit2D (Collision2D col) {
		if (onCollisionExitEvent != null) {
			onCollisionExitEvent (col);
		}
	}
	
	public void OnMouseDown () {
		if (onMouseButtonEvent != null) {
			onMouseButtonEvent ();
		}
	}

	public void Destroy () {
		Destroy (gameObject);
	}

	public void Destroy (float duration) {
		Destroy (duration);
	}
}