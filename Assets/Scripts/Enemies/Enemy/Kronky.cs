using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Kronky : MonoBehaviour {

	public Vector2 _kongVelocity;

	public Vector2 KongVelocity {
		get { return _kongVelocity; }
		set { _kongVelocity = value; }
	}

	public void Awake () {}

	public void Start () {}
	
	public void OnTriggerEnter2D (Collider2D collider) {}

	public void KronkyDie () {}
}