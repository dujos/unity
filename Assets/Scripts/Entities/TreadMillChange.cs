using UnityEngine;
using System.Collections;

public class TreadMillChange : TreadMill {
	public float waitDuration;
	private Transform currentTrack;
	private Transform previousTrack;
	
	public void Awake () {
		foreach (Transform child in transform) {
			if (child.name == "TrackOn") {
				currentTrack = child;
				currentTrack.gameObject.SetActive (true);
			} else {
				previousTrack = child;
				previousTrack.gameObject.SetActive (false);
			}
		}
	}

	public void Start () {
		InvokeRepeating ("ChangeTreadState", 0, waitDuration);
	}

	public void ChangeTreadState () {
		Transform temp;
		temp = currentTrack;
		currentTrack = previousTrack;
		previousTrack = temp;
		previousTrack.gameObject.SetActive (false);
		currentTrack.gameObject.SetActive (true);
	}
}