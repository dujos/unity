﻿using UnityEngine;
using System.Collections;

public class Saw : MonoBehaviour {
	private Vector3 axis { get; set; }
	private float speed { get; set; }

	public void Start () {
		speed = 120;
		axis = Vector3.back;

		PathMovement.onPathEnd += SawStop;
	}

	public void OnTriggerEnter2D (Collider2D collider) {
		var kong = collider.GetComponent<Kong> ();
		if (kong) {
			ResetPathMovement ();
		}
	}

	private void ResetPathMovement () {
		gameObject.GetComponent<PathMovement> ().ResetPathIndex ();
	}

	private void StopMovement () {

	}

	private void SawStop () {
		Destroy (gameObject);
	}
	
	public void Update () {
        transform.Rotate (axis, speed * Time.deltaTime);
    }
}