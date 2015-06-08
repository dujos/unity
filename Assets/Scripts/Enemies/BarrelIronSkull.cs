using UnityEngine;
using System.Collections;

public class BarrelIronSkull : MonoBehaviour {
	public int cycles;
	private float repeatRate;
	private GameObject kong;

	// Use this for initialization
	void Start () {
		repeatRate = 3f;
	}

	public void OnTriggerEnter2D (Collider2D collider) {
		kong = collider.gameObject;
	}
}