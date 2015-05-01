using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Transform destination;

	public void Start () {

	}

	void Update () {
		float pointReached = (destination.position - transform.position).sqrMagnitude;
		if (pointReached < 0.1f) {
			DestroyBullet ();
		}
	}
	
	public void DestroyBullet () {
		gameObject.SetActive (false);
	}
}
