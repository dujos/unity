using UnityEngine;
using System.Collections;

public class PathBullet : MonoBehaviour {

	/*
	public Bullet bullet;
	public Transform destination;
	public float speed;
	public float fireRate;
	public int numberOfBullets;

	// Use this for initialization
	public void Start () {
		if (numberOfBullets > 0) {
			StartCoroutine (SpawnLimitedPathBulletCo ());
		} else {
			StartCoroutine (SpawnUnLimitedPathBulletCo ());
		}
	}

	public IEnumerator SpawnLimitedPathBulletCo () {
		while (numberOfBullets > 0) {
			Bullet b = (Bullet)Instantiate (bullet, transform.position, transform.rotation);
			b.Init (destination, speed);
			yield return new WaitForSeconds (fireRate);
			numberOfBullets--;
		}
		yield return 0;
	}
	
	public IEnumerator SpawnUnLimitedPathBulletCo () {
		while (true) {
			Bullet b = (Bullet)Instantiate (bullet, transform.position, transform.rotation);
			b.Init (destination, speed);
			yield return new WaitForSeconds (fireRate);
		}
	}
	
	public void OnDrawGizmos () {
		Gizmos.color = Color.red;
		var to = transform.position + destination.position;
		Gizmos.DrawLine (transform.position, to);
	}
*/
}