using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

	public Transform destination;

	public void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float pointReached = (destination.position - transform.position).sqrMagnitude;
		if (pointReached < 0.1f) {
			DestroyRocket ();
		}
	}
	
	public void DestroyRocket () {
		gameObject.SetActive (false);
	}
}