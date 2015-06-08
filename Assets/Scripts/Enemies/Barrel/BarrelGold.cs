using UnityEngine;
using System.Collections;

public class BarrelGold : MonoBehaviour {
	public GameObject[] bullets;
	public float repeatRate;

	// Use this for initialization
	void Start () {
		repeatRate = 1f;
		InvokeRepeating ("FireGoldBullet", 0, repeatRate);
	}

	public void FireGoldBullet () {
		for (int i = 0; i < bullets.Length; i++) {
			PoolManager.Spawn (bullets[i], transform.position, Quaternion.identity);
		}
	}
}
