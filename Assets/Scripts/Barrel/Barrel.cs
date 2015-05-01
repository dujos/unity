using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour {
	protected Animator animator;
	protected Animation animation;
	protected Kong kong;
    
    protected bool isKongInside;

	public float duration;
	public bool lookActive;
	protected LookAtTarget look;
	    
	public void Start () {
		isKongInside = false;

		animator = transform.GetComponent<Animator> ();
		animation = transform.GetComponent<Animation> ();
		if (lookActive) {
			look = transform.GetComponent<LookAtTarget> ();
		}
    }

	public virtual void OnTriggerEnter2D (Collider2D collider) {
		kong = collider.gameObject.GetComponent<Kong> ();
		if (kong) {
			isKongInside = true;
            kong.KongEnterBarrel (transform);
			StartCoroutine (AnimationCo ("BarrelCollision", true));

			if (look) {
				StartLookAtTarget ();
			}
        }
    }

	public virtual void OnTriggerExit2D (Collider2D collider) {
		kong = collider.gameObject.GetComponent<Kong> ();
		if (kong) {
			isKongInside = false;
			StartCoroutine (AnimationCo ("BarrelSmoke", true));
		}
	}

	public void StartLookAtTarget () {
		if (duration > 0) {
			look.TransformLookAtTargetWithDuration (duration);
		} else {
			look.TransformLookAtTarget ();
		}
	}

	public IEnumerator AnimationCo (string nameState, bool state) {
		animator.SetBool (nameState, state);
		yield return new WaitForSeconds(this.animation.clip.length);
		animator.SetBool (nameState, !state);
    }  
}