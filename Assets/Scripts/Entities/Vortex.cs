using UnityEngine;
using System.Collections;

public class Vortex : MonoBehaviour {
	private KongController kong;
	private Rotate rotate;

	// Use this for initialization
	void Start () {
		kong = GameObject.Find ("Kong").GetComponent<KongController> ();
		rotate = GetComponent<Rotate> ();
		rotate.Move ();
	}

	public void OnTriggerEnter2D (Collider2D collider) {
		kong.Body.gravityScale = 0f;
	}

	public void Update () {
		if (kong.gameObject.transform.position == gameObject.transform.position) {
			kong.GetComponent<MotorKong> ().Stop ();
			kong.SetKongPosition (Geometry.Vec2 (gameObject.transform));
		}
	}
}