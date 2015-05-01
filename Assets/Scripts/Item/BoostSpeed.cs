using UnityEngine;
using System.Collections;

public class BoostSpeed : Boost {
	public float speed { get; set; }
	public float duration { get; set; }

	public void Awake () {
		speed = 25;
	}

	public void OnTriggerEnter2D (Collider2D collider) {
		var kong = collider.GetComponent<Kong> ();
		if (kong) {
			if (onPickedBoost != null) {
				onPickedBoost (gameObject);
				/*
				 * 
				 * When is the gameobject destroyed
				 */
				Destroy (gameObject);
			}
		}
	}
}