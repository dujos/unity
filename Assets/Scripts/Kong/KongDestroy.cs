using UnityEngine;
using System.Collections;

public class DestroyKong : MonoBehaviour {
	public float waitToDestroy;

	void Start () {
		if (transform.childCount > 0) {
			Invoke ("ActivateDestroyKong", waitToDestroy);
		} else {
			Invoke ("ActivateDestroyKong", 0);
		}
	}

	public void ActivateDestroyKong () {
		Destroy (gameObject);
	}
}
