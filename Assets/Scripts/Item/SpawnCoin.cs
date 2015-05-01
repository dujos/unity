using UnityEngine;
using System.Collections;

public class SpawnCoin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//KongDetector.onKongDetect += SpawnACoin;
	}
	
	public void SpawnACoin (KongDetector detector) {
		/*
		Coin coin = FindObjectOfType<Coin> ();
		coin.gameObject.SetActive (true);
		coin.axis = detector.axis;
		coin.speed = detector.speed;

		Instantiate (coin, transform.position, transform.rotation);
		*/
	}
}
