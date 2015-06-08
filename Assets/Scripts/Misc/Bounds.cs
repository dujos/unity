using UnityEngine;
using System.Collections;

public class Bounds : MonoBehaviour {

	public void OnTriggerExit2D (Collider2D collider) {
		Destroy (collider.gameObject);
	}
}