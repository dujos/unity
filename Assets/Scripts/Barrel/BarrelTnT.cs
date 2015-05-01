using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class BarrelTnT : Barrel {

	public void Start () {
		animator = gameObject.GetComponent<Animator> ();
		animation = gameObject.GetComponent<Animation> ();
	}

	public void OnTriggerEnter2D (Collider2D collider) {
		var kong = collider.gameObject.GetComponent<Kong> ();	
		if (kong) {
			animator.SetBool ("Explode", true);
			StartCoroutine (Die ());
		}
	}
	
	private IEnumerator Die() {
		yield return new WaitForSeconds (this.animation.clip.length);
		Destroy(gameObject);
    }
}
