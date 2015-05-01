using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pooler : MonoBehaviour {

	private List<GameObject> pool;
	private List<Tuple<GameObject, int>> projectiles;    
    
    public GameObject rocket;
	public GameObject bullet;

	public static Pooler instance;

	public void Awake () {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		pool = new List<GameObject> ();

		projectiles = new List<Tuple<GameObject, int>> ();
		if (rocket != null)
            projectiles.Add (new Tuple<GameObject, int> (rocket, 3));

		if (bullet != null)
			projectiles.Add (new Tuple<GameObject, int> (bullet, 4));

        foreach (Tuple<GameObject, int> tuple in projectiles) {
			for (int i = 0; i < tuple.Second; i++) {
				GameObject temp = (GameObject) Instantiate (tuple.First);
				temp.SetActive (false);
                pool.Add (temp);
			}
        }
	}

	public Pooler GetInstance () {
		return instance;
	}

	public GameObject GetPooledObjects () {
		foreach (GameObject temp in pool) {
			if (!temp.activeInHierarchy) {
				return temp;
			}
		}
		return null;
	}
}