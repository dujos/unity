using UnityEngine;
using System.Collections;

public class Scale : MonoBehaviour {
	private Vector3 fromScale;
	private Vector3 toScale;

	public float scaleFactor;
	public float duration;
	public float waitDuration;

	private bool isTriggable;

	public void Awake () {
		isTriggable = true;
		fromScale = transform.localScale;
		toScale = fromScale * scaleFactor;
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (ScaleCo ());
	}

	public IEnumerator ScaleCo () {
		var from = fromScale;
		var to = toScale;

		while (true) {
			transform.localScale = Auto.Wave(duration, from, to);
			transform.position = Auto.Wave (duration, from, to);
			if (from == transform.position) {
				isTriggable = true;
				yield return StartCoroutine(Auto.Wait(waitDuration));
			}
			isTriggable = false;
			yield return 0;
		}
	}

	public void Update () {
		if (isTriggable) {
			ActivateComponents (true);
		} else {
			ActivateComponents (false);
		}
	}

	private void ActivateComponents (bool state) {
		gameObject.GetComponent<CircleCollider2D> ().enabled = state;
	}
}