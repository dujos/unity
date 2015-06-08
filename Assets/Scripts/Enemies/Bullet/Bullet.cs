using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float wait;
	protected Motor motor;
	private float temp;

	public void Start () {
		temp = 0;
	}

	public void Update () {
		if (temp > wait) {
			PoolManager.DestroyPrefab (gameObject);
			temp = 0;
		}
		temp += Time.deltaTime;
	}
}