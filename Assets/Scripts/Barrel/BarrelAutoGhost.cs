using UnityEngine;
using System.Collections;

public class BarrelAutoGhost : BarrelAuto {
	public float ghostDurationOn;
	public float ghostDurationOff;

	// Use this for initialization
	void Start () {
		StartCoroutine (GhostBarrelCo ());
	}
	
	public void GhostBarrelVisible (bool visible) {
		transform.gameObject.GetComponent<SpriteRenderer> ().enabled = visible;
	}
	
	private IEnumerator GhostBarrelCo () {
		while(true) {
			GhostBarrelVisible (false);
			transform.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			yield return new WaitForSeconds(ghostDurationOff);
			GhostBarrelVisible (true);
			transform.gameObject.GetComponent<CircleCollider2D> ().enabled = true;
			yield return new WaitForSeconds(ghostDurationOn);
		}
	}
}