using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Kong : Entity {
	private bool canKongMove;
	private bool canKongDie;

	delegate void KongState();
	private KongState ChangeKongState;

	private Transform checkPoint;

	private KongAnimation kongAnimation;
	private KongController kongController;

	private List<GameObject> kongBoosters;

	void Awake () {
		kongAnimation = GetComponent<KongAnimation> ();
		kongController = GetComponent<KongController> ();

		kongBoosters = new List<GameObject> ();
		Boost.onPickedBoost += AddBoost;
		checkPoint = null;

	}

	// Use this for initialization
	void Start () {
		canKongDie = true;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void AddBoost (GameObject boost) {
		/*
		if (!kongBoosters.Contains (boost)) {
			kongBoosters.Add (boost);
		}
		*/

		if (boost.name.Equals ("BoostSpeed")) {
			var speed = boost.GetComponent<BoostSpeed> ().speed;
			kongController.SetKongSpeed (speed);
		} else if (boost.name.Equals ("BoostWater")) {
			//boost.GetComponent<BoostWater> ();
		} else if (boost.name.Equals ("BoostFire")) {
			//boost.GetComponent<BoostFire> ();
		}
	}

	public List<GameObject> GetBoost () {
		return kongBoosters;
	}

	public void SetKongActive (bool active) {
		gameObject.GetComponent<SpriteRenderer> ().enabled = active;
	}

	public void KongBoostFire () {
		var boost = kongBoosters.Find (t => t.name == "BoostFire");
		if (boost) {
			Boost.onPickedBoost -= AddBoost;
			kongBoosters.Remove (boost);
		}
	}

	public void KongBoostWater () {
		var boost = kongBoosters.Find (t => t.name == "BoostWater");
		if (boost) {
			Boost.onPickedBoost -= AddBoost;
			kongBoosters.Remove (boost);
		}
	}

	public void KongPunch () {
        kongAnimation.KongPunch ();
	}
    
    public void KongEnterBarrel (Transform target) {
		kongAnimation.KongEnterBarrel (false);
		SetKongActive (false);

		kongController.SetKongMoving (false);
		kongController.SetKongPosition (target);
	}

	public void KongExitBarrel (Transform target) {
		kongAnimation.KongExitBarrel (true);
		SetKongActive (true);

		kongController.SetKongMoving (true);
		kongController.SetKongDirection (target);
	}

	public void KongBumpToSurface (Transform target) {
		kongController.SetKongDirection (target);
	}

	public void SetKongCheckPoint (Transform point) {
		checkPoint = point.transform;
	}

	public void KongSpawn () {
		StartCoroutine (KongSpawnCo ());
	}

	private IEnumerator KongSpawnCo () {
		kongController.SetKongMoving (false);
		yield return new WaitForSeconds (0.5f);
		transform.position = checkPoint.position;
		kongController.SetKongMoving (true);
		//kongAnimation.KongDie (false);
	}

	public void KongDie (string nameOfEnemy) {
		Debug.Log (nameOfEnemy);
		//kongAnimation.KongDie (true);
		//KongSpawn ();
		//canKongMove = false;
	}

	public void KongBoost () {
		StartCoroutine (KongBoostCo ());
	}

	private IEnumerator KongBoostCo () {
		//SetKongAnimation ("Boost", true);
		//StartParticles ();
		canKongDie = false;

		yield return new WaitForSeconds (4);

		//SetKongAnimation ("Boost", false);
		canKongDie = true;
	}

	public void SetColliders(bool enabled) {
		Collider[] colliders = GetComponentsInChildren<Collider>();
		foreach(Collider collider in colliders) {
			collider.enabled = enabled;
		}
	}
}