using UnityEngine;
using System.Collections;

public class Barrel : Entity {
	protected bool isKongInside;
    
    // Use this for initialization
	void Start () {
		isKongInside = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
	public void DestroyBarrel () {
		Transform[] transforms = transform.GetComponentsInChildren<Transform> ();
		foreach (Transform tr in transforms) {
			Destroy (tr);
		}
	}
	*/
}
