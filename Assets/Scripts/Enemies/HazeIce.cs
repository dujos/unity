using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HazeIce : MonoBehaviour {	
	public Transform destination;
	
	public void Start () {
		Transform parentPosition = transform.gameObject.GetComponentInParent<Transform> ();
		transform.position += parentPosition.position;
		destination.position += parentPosition.position;
	}
	
	void Update () {
		float pointReached = (destination.position - transform.position).sqrMagnitude;
		if (pointReached < 0.1f) {
			DestroyBullet ();
		}
	}
	
	public void OnTriggerEnter2D (Collider2D collider) {
		
	}
	
	public void DestroyBullet () {
		gameObject.SetActive (false);
	}
}