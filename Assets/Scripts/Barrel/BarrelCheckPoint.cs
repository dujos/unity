using UnityEngine;
using System.Collections;

public class BarrelCheckPoint : Barrel {
	private bool visited;

	public delegate void BarrelCheckPointHandler ();
	public static BarrelCheckPointHandler onEnterBarrel;

	// Use this for initialization
	void Start () {
		visited = false;
	}

	public void Update () {

	}

	public bool IsVisited () {
		return visited;
	}

	public void EnterCheckPoint (Kong kong) {
		visited = true;
		//kong.SetKongCheckPoint (transform);
		isKongInside = true;
	}
	
	public void ExitCheckPoint () {
		isKongInside = false;
	}

	public void OnTriggerEnter2D (Collider2D collider) {
		var kong = collider.GetComponent<Kong> ();
		if (kong && !isKongInside) {
			onEnterBarrel ();
		}
	}
}