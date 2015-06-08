using UnityEngine;
using System.Collections;

public class BarrelDestroy : MonoBehaviour {
	public float wait;

	// Use this for initialization
	void Start () {}

	public void DestroyBarrel () {
		Destroy (gameObject);
	}

	public void DestroyBarrelWithWait () {
		Destroy (gameObject, wait);
	}

	public void SetBarrelActivate (bool active) {
		gameObject.SetActive (active);
	}
}