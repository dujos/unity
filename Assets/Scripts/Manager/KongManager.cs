using UnityEngine;
using System.Collections;

public class KongManager : MonoBehaviour {

	private GameObject[] barrels;
	private GameObject[] enemies;
	private GameObject[] items;
	private GameObject[] points;
	private GameObject kong;

	private static bool created = false;

	void Awake () {
		if (!created) {
			DontDestroyOnLoad (gameObject);
			kong = GetKong ();

			barrels = LoadEntities ("Barrel");
			points = LoadEntities ("Point");
			enemies = LoadEntities ("Enemy");
			items = LoadEntities ("Item");
            
            created = true;
		} else {
			Destroy (gameObject);
		}
	}

	public GameObject GetBarrel (string name) {
		foreach (GameObject barrel in barrels) {
			if (barrel && barrel.name.Equals (name)) {
				return barrel;
			}
		}
		return null;
	}

	public GameObject GetItem (string name) {
		foreach (GameObject item in items) {
			if (item && item.name.Equals (name)) {
				return item;
            }
        }
        return null;
    }
	
	public GameObject GetPoint (string name) {
		foreach (GameObject point in points) {
			if (point && point.name.Equals (name)) {
				return point;
			}
		}
        return null;
    }

	public GameObject GetEnemy (string name) {
		foreach (GameObject enemy in enemies) {
			if (enemy && enemy.name.Equals (name)) {
				return enemy;
			}
        }
        return null;
    }    
    
    private GameObject[] LoadEntities (string name) {
		return GameObject.FindGameObjectsWithTag (name);
	}    	

	public GameObject GetKong () {
		return GameObject.FindGameObjectWithTag ("Kong");
	}
}