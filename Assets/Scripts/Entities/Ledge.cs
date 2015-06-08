using UnityEngine;
using System.Collections;

public class Ledge : MonoBehaviour {
	public delegate void KongAction ();
	public static event KongAction OnKongAction;
	private bool ledgeOn;
	
	public void Start () {
		ledgeOn = true;
	}

	void OnCollisionStay2D (Collision2D coll) {
		if (coll.gameObject.name == "Kong") {
			if (OnKongAction != null) {
				ledgeOn = false;
				OnKongAction ();
			}
		}
	}

	public void OnCollisionExit2D (Collision2D coll) {
		if (coll.gameObject.name == "Kong") {
			//gameObject.GetComponent<PlatformEffector2D> ().colliderMask = 1;
		}
	}

	public void OnMouseDown () {
		if (!ledgeOn) {
			if (OnKongAction != null) {
				gameObject.GetComponent<PlatformEffector2D> ().colliderMask = 0;
				OnKongAction ();
			}
		}
	}
}