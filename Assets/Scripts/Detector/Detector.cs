using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Detector : MonoBehaviour {
	public delegate void DetectorHandler();
	public static event DetectorHandler OnDetectedOn;
	public static event DetectorHandler OnDetectedOff;

	public void Start () {}

	public void OnTriggerEnter2D (Collider2D collider) {
		if (collider.name == "Kong") {
			if (OnDetectedOn != null) {
				OnDetectedOn ();
			}
		}
	}
	
	public void OnTriggerExit2D (Collider2D collider) {
		if (collider.name == "Kong") {
			if (OnDetectedOff != null) {
				OnDetectedOff ();
			}
		}
	}
}