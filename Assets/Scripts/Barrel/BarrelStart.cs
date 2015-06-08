using UnityEngine;
using System.Collections;

public class BarrelStart : BarrelKong {

	public void OnTriggerEnter2D (Collider2D collider) {
		kong = collider.gameObject.GetComponent<Kong> ();
		if (kong) {
			base.OnTriggerEnter2D (collider);
			kong.GetComponent<Rigidbody2D> ().gravityScale = 0;
			kong.GetComponent<KongAnimation> ().KongTrigger ("Land");
			//kong.GetComponent<KongController> ().KongStop ();
		}
	}	
}