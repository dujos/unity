using UnityEngine;
using System.Collections;

public class KillKong : MonoBehaviour {

	public void OnTriggerEnter2D (Collider2D collider) {
		var kong = collider.GetComponent<Kong> ();
		if (kong) {
			kong.KongDie (gameObject.name);
		}
	}
}