using UnityEngine;
using System.Collections;

public class BarrelMark : Barrel {

	// Use this for initialization
	void Start () {
	
	}

	public void OnTriggerEnter2D (Collider2D collider) {
		var kong = collider.GetComponent<Kong> ();
		
		if (kong) {
			//kong.KongBoost ();
			Debug.Log ("trigger" + gameObject.name);
		}
	}

}
