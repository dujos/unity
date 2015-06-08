using UnityEngine;
using System.Collections;

public class SpawnToken : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//KongDetector.onKongDetect += SpawnAToken;
	}

	public void SpawnAToken () {
		//Debug.Log ("Spawn Token");

		/*
		Token token = FindObjectOfType<Token> ();
		if (token) {
			token.gameObject.SetActive (true);
			token.enabled = true;
			//token.axis = detector.axis;
			//token.speed = detector.speed;
			Instantiate (token, transform.position, transform.rotation);
		}
		*/
	}
}
