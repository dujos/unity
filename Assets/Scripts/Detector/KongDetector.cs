using UnityEngine;
using System.Collections;

public class KongDetector : MonoBehaviour {

	public Vector3 axis;
	public float speed;

	public delegate void OnKongDetectHandler ();
	public static OnKongDetectHandler onKongDetect; 

	public void OnTriggerEnter2D (Collider2D collider) {
		var kong = collider.gameObject.GetComponent<Kong> ();
		if (kong) {
			if (onKongDetect != null) {
				//collider.enabled = false;
				onKongDetect ();
			}
		}
	}
}