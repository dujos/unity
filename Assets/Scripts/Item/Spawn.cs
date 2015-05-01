using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {
	public static Spawn current;
	public GameObject[] prefabs;
	public int amount;

	private GameObject container;
	private List<GameObject>[] pool;

	public void Start () {
		if (current == null) {
			current = this;
		} else {
			Destroy (gameObject);
		}

		container = new GameObject ("Spawn");
		pool = new List<GameObject>[prefabs.Length];

		for (int i = 0; i < prefabs.Length; i++) {
			pool[i] = new List<GameObject> ();
			for (int j = 0; j < amount; j++) {
				GameObject target = (GameObject) Instantiate(prefabs[j]);
				target.name = prefabs[j].name;
                Pool (prefabs[j]);
            }
        }
	}

	public GameObject GetSpawn (GameObject spawn) {
		for (int i = 0; i < prefabs.Length; i++) {
			if (spawn.name == prefabs[i].name) {
				if(pool[i].Count > 0) {
					GameObject target = pool[i][0];
					pool[i].RemoveAt(0);
                    target.transform.parent = null;
                    return target;
                }
			}
		}
		return null;
	}

	public void Pool (GameObject target) {
		for (int i = 0; i < prefabs.Length; i++) {
			if(prefabs[i].name == target.name) {
				target.SetActive(false);
				target.transform.parent = container.transform;
                pool[i].Add(target);
                return;
            }
        }
	}

	/*
	public enum SpawnItem { Star, Token, Coin }
	public SpawnItem item;

	private Star star;
	private Coin coin;
	private Token token;

	public void Start () {
		if (item == SpawnItem.Star) {
			star = GameObject.Find ("Star").GetComponent<Star> ();
		} else if (item == SpawnItem.Coin) {
			token = GameObject.Find ("Token").GetComponent<Token> ();
		} else if (item == SpawnItem.Token) {
			coin = GameObject.Find ("Coin").GetComponent<Coin> ();
		}
	}

	public void OnTriggerEnter2D (Collider2D collider) {
		var kong = collider.GetComponent<Kong> ();
		if (kong) {

		}
	}

	public void ActivateTarget () {
		if (item == SpawnItem.Star) {
			star = GameObject.Find ("Star").GetComponent<Star> ();
		} else if (item == SpawnItem.Coin) {
			token = GameObject.Find ("Token").GetComponent<Token> ();
		} else if (item == SpawnItem.Token) {
			coin = GameObject.Find ("Coin").GetComponent<Coin> ();
		}
	}

	public void GenerateStars () {
		int numStars = 11;
		float radius = 2;
		
		if (numStars <= 0)
			return;
		
		float delta = 360 / numStars;
		float angle = 0;
		
		for (int i = 0; i < numStars; i++) {
			angle = delta * i;
			Vector3 pos = new Vector3 (Mathf.Cos (angle)*radius, 
			                           Mathf.Sin (angle)*radius, 0);
			//Instantiate (target);
			//target.transform.position = pos;
		}
	}
	*/
}