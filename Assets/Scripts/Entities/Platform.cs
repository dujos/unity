using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	public void OnTriggerEnter2D (Collider2D collider) {
		if (collider.name == "KongController") {

		}
	}
}