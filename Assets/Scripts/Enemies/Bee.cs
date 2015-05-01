﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bee : Enemy {
	private Vector3 axis { get; set; }
	private float speed { get; set; }
	
	private Collider2D headCollider;
	private Collider2D stingerCollider;

	public void Start () {
		animator = transform.gameObject.GetComponent<Animator> ();
		animation = gameObject.GetComponent<Animation> ();
        
        headCollider = transform.Find("Head").GetComponent<Collider2D> ();
		stingerCollider = transform.Find("Stinger").GetComponent<Collider2D> ();

		animator.SetBool ("Idle", true);
		StartCoroutine (RotateBeeCo ());
	}

	public IEnumerator RotateBeeCo () {
		while (true) {
			transform.localScale = new Vector3 (transform.localScale.x * (-1), 
				transform.localScale.y, transform.localScale.z);
			yield return new WaitForSeconds (2f);
		}
	}

	public void OnTriggerEnter2D (Collider2D collider) {
		var kong = collider.GetComponent<Kong> ();
		if (collider.bounds.Intersects (headCollider.bounds)) {
			animator.SetBool ("Idle", true);
            kong.KongPunch ();
			headCollider.enabled = false;
			stingerCollider.enabled = false;
			BeeDie ();
        } else if (collider.bounds.Intersects (stingerCollider.bounds)) {
			headCollider.enabled = false;
			stingerCollider.enabled = false;
			kong.KongDie (gameObject.name);
        }
	}

	public void BeeDie () {
		animator.SetBool ("Die", true);
		StartCoroutine (Die ());
	}

    private IEnumerator Die() {
		yield return new WaitForSeconds (this.animation.clip.length * 2f);
		Destroy(gameObject);
	}
}