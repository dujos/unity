using UnityEngine;
using System.Collections;

public class TeleportPoint : MonoBehaviour {

	public TeleportPoint next;

	// Use this for initialization
	void Start () {
	}

	public void OnTriggerEnter2D (Collider2D collider) {
		
		var kong = collider.GetComponent<Kong> ();
		if (kong && next) {
			//kong.KongTeleport (next.transform);
		}
	}
}
