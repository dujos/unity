using UnityEngine;
using System.Collections;

public class Secret : MonoBehaviour {

	public GameObject secret;
	public Vector3 secretPosition;
	private bool active;

	void Start () {
		secret.SetActive (false);
		active = false;
	}

	public virtual void OnTriggerEnter2D (Collider2D collider) {
		if (collider.name == "Kong" && !active) {
			Vector3 position = Vector3.zero == secretPosition ? transform.position : secretPosition;
			Instantiate (secret, position, Quaternion.identity);
			gameObject.SetActive (false);
			active = true;
		}
    }
}