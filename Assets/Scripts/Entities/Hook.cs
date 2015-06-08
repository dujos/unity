using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour {
	public delegate void KongAction (Vector2 position);
	public static event KongAction OnKongAction;

	public void Start () {}

	public void OnTriggerEnter2D (Collider2D collider) {
		if (collider.name == "Kong") {
			if (OnKongAction != null) {
				OnKongAction (Geometry.Vec2 (transform));
			}
		}
	}
}