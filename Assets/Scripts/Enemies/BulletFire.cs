using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletFire : MonoBehaviour {
	private float fireTime;
	private float fireRate;

	public void Awake () {
		fireTime = 0.4f;
		fireRate = 5f;
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Fire", fireRate, fireTime);
	}

	public void Fire () {
		GameObject bullet = Pooler.instance.GetPooledObjects ();

		if (bullet == null)
			return;

		bullet.transform.position = transform.position;
		bullet.transform.rotation = transform.rotation;
		bullet.SetActive (true);
	}
}