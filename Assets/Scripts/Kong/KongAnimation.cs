using UnityEngine;
using System.Collections;

public class KongAnimation : MonoBehaviour {

	private Animator animator;
	private Kong kong;

	public void Start () {
		animator = GetComponent<Animator> ();
		kong = gameObject.GetComponent<Kong> ();
	}

	public void KongBoost (bool state) {
		animator.SetBool ("Boost", state);
	}

	public void KongPunch () {
		animator.Play ("KongPunching");
    }

	public void KongTrigger (string trigger) {
		animator.SetTrigger ("Land");
	}

	public void KongDie (bool state) {
		animator.SetBool ("Dying", state);
	}

	public void KongRoll (bool state) {
		animator.SetBool ("Roll", true);
	}
	
	public void KongMove (bool state) {
		animator.SetBool ("Moving", state);
	}

	public void KongWalk (bool state) {
		animator.SetBool ("Walking", state);
	}
	
	public void KongFall (bool state) {
		//animator.Play ("KongFalling");
		animator.SetBool ("Falling", state);
	}

	public void KongEnterBarrel (bool state) {
		KongMove (state);
	}

	public void KongExitBarrel (bool state) {
		KongMove (state);
	}
}