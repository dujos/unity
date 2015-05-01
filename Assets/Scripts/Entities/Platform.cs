using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	public void OnTriggerEnter2D (Collider2D collider) {
		Kong kong = collider.gameObject.GetComponent<Kong> ();
		if (kong) {
			kong.KongBumpToSurface (transform);
		}
	}
}