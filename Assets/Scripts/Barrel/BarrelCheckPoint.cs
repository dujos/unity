using UnityEngine;
using System.Collections;

public class BarrelCheckPoint : Barrel {

	public delegate void BarrelCheckPointHandler ();
	public static BarrelCheckPointHandler onEnterBarrel;

	// Use this for initialization
	void Start () {
		isKongInside = false;
	}

	public void Update () {

	}

	public void EnterCheckPoint (Kong kong) {
		kong.SetKongCheckPoint (transform);
		isKongInside = true;
	}
	
	public void ExitChekPoint () {
		
	}

	public void OnTriggerEnter2D (Collider2D collider) {
		var kong = collider.GetComponent<Kong> ();
		if (kong && !isKongInside) {
			onEnterBarrel ();
		}
	}
}