using UnityEngine;
using System.Collections;

public class BarrelAuto : Barrel {
	public float waitBarrel; 

	public void Start () {
		animator = transform.GetComponent<Animator> ();
		animation = transform.GetComponent<Animation> ();

		if (lookActive) {
			look = transform.GetComponent<LookAtTarget> ();
		}

		isKongInside = false;
	}
	
	public override void OnTriggerEnter2D (Collider2D collider) {
		kong = collider.gameObject.GetComponent<Kong> ();
		if (kong) {
			isKongInside = true;
			kong.KongEnterBarrel (transform);
			StartCoroutine (AnimationCo ("BarrelCollision", true));

			if (look) {
				StartLookAtTarget ();
			}

			StartCoroutine (ExitBarrelCo (kong));
        }
	}

	public override void OnTriggerExit2D (Collider2D collider) {
		kong = collider.gameObject.GetComponent<Kong> ();
		if (kong) {
			isKongInside = false;
			StartCoroutine (AnimationCo ("BarrelSmoke", true));
		}
	}

	public IEnumerator ExitBarrelCo (Kong kong) {
		yield return new WaitForSeconds (waitBarrel);
		kong.KongExitBarrel (transform);
	}
}
