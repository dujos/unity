using UnityEngine;
using System.Collections;

public class BarrelEnemy : MonoBehaviour {
	private GameObject kong;
	public GameObject bullet;

	public float wait;
	public float repeatRate;

	/*
	private Sprites sprites;
	public enum Enemies { GreenKremlin, RedKremlin, PurpleKremlin, 
		BarrelTnt, BarrelFire, BarrelIce };
	public Enemies kremlinType;
	*/

	// Use this for initialization
	void Start () {
		kong = GameObject.Find ("Kong");
		Fire ();

		/*
		sprites = new Sprites ();
		string bulletsPath = "Textures/Bullets";
		string barrelEnemiesPath = "Textures/BarrelEnemies";
		sprites.LoadSprites (bulletsPath);
		sprites.LoadSprites (barrelEnemiesPath);
		sprites.GetSprites (bulletsPath);
		sprites.GetSprites (barrelEnemiesPath);
		*/
	}

	public void Fire () {
		InvokeRepeating ("FireBullet", wait, repeatRate);
	}

	public void FireBullet () {
		PoolManager.Spawn (bullet, transform.position, Quaternion.identity);
	}
}