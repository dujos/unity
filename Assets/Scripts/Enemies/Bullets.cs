using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullets : MonoBehaviour {
	private float fireTime;
	private float fireRate;
	public GameObject bullet;

	public void Awake () {
		fireTime = 1f;
		fireRate = 1f;
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Fire", fireRate, fireTime);
	}

	public void Fire () {
		GameObject temp = (GameObject) Instantiate (bullet);
        
        temp.transform.position = transform.position;
		temp.transform.rotation = transform.rotation;
		temp.SetActive (true);
	}
}