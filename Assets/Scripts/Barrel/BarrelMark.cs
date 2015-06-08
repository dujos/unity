using UnityEngine;
using System.Collections;

public class BarrelMark : Barrel {
	private GameObject bd;

	public void Start () {
		//GameObject bd = GameObject.Find ("BarrelDestroy");
		//bd.SetActive (false);
		//bd.GetComponent<SpriteRenderer> ().enabled = false;
    }

	public void OnTriggerEnter2D (Collider2D collider) {
		var kong = collider.GetComponent<Kong> ();
		if (kong) {
			//kong.KongBoost ();

			//BarrelDestroy barrelDestroy = bd.GetComponent<BarrelDestroy> ();
			//transform.GetComponent<SpriteRenderer> ().enabled = false;
            //bd.GetComponent<SpriteRenderer> ().enabled = true;
			//bd.SetActive (true);
        }
	}
}