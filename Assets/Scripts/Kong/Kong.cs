using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Kong : Entity {
	/*
	private bool canKongDie;

	delegate void KongState();
	private KongState ChangeKongState;

	private Transform checkPoint;

	private KongAnimation kongAnimation;
	private KongController kongController;

	private List<GameObject> kongBoosters;
	private bool isKongInsideBarrel;

	void Awake () {
		checkPoint = transform;
	}

	// Use this for initialization
	void Start () {
		canKongDie = true;
		isKongInsideBarrel = false;

		kongAnimation = GetComponent<KongAnimation> ();
		kongController = GetComponent<KongController> ();
		
		kongBoosters = new List<GameObject> ();
		Boost.onPickedBoost += AddBoost;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SetIsKongInsideBarrel (bool state) {
		isKongInsideBarrel = state;
	}

	public bool IsKongInsideBarrel () {
		return isKongInsideBarrel;
	}

	public void AddBoost (GameObject boost) {
	
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
		SetIsKongInsideBarrel (true);

		//kongController.SetKongMoving (false);
		//kongController.KongStop ();
		kongController.SetKongPosition (target);
	}

	public void KongExitBarrel (Transform target) {
		kongAnimation.KongExitBarrel (false);
		SetKongActive (true);
		SetIsKongInsideBarrel (false);

		//kongController.SetKongMoving (true);
		//kongController.KongMove ();
		kongController.SetKongDirection (target);
	}

	public void KongBumpToSurface (Transform target) {
		kongController.SetKongDirection (target);
	}

	public void SetKongCheckPoint (Transform point) {
		checkPoint = point;
	}

	public void KongSpawn () {
		StartCoroutine (KongSpawnCo ());
	}

	private IEnumerator KongSpawnCo () {
		yield return new WaitForSeconds (1f);
		kongController.SetKongMoving (false);
		yield return new WaitForSeconds (2f);
		transform.position = checkPoint.position;
		kongController.SetKongMoving (true);
		kongAnimation.KongDie (false);
	}

	public void KongStop () {
		kongController.KongStop ();
	}

	public void KongDie (string nameOfEnemy) {
		kongAnimation.KongDie (true);
		KongSpawn ();
	}

	public void KongWalk (bool state) {
		kongAnimation.KongWalk (state);
	}

	public void KongFall (bool state) {
		StartCoroutine (KongFallCo ());
	}

	public IEnumerator KongFallCo () {
        kongAnimation.KongFall (true);
		yield return new WaitForSeconds (kongAnimation.GetComponent<Animation> ().clip.length*2);
		kongAnimation.KongFall (false);
		kongAnimation.KongMove (true);
        kongController.KongMove ();
	}

	public void SetKongDirection (Vector2 direction) {
		kongController.SetKongDirection (direction);
	}

	public Vector2 GetKongDirection () {
		return kongController.GetKongDirection ();
	}

	public float GetKongSpeed () {
		return kongController.GetKongSpeed ();
	}


	public void KongMove (bool state) {
		kongAnimation.KongMove (state);
	}

	public void KongBoost () {
		StartCoroutine (KongBoostCo ());
	}

	private IEnumerator KongBoostCo () {
		KongBlink blink = new KongBlink ();
		blink.SetBlinkDuration (0f, 0f, 0.1f);
		transform.gameObject.AddComponent<KongBlink> ();

		kongAnimation.KongBoost (true);
		canKongDie = false;
		yield return new WaitForSeconds (4);
		kongAnimation.KongBoost (false);
		canKongDie = true;
	}

	public void SetColliders(bool enabled) {
		Collider[] colliders = GetComponentsInChildren<Collider>();
		foreach(Collider collider in colliders) {
			collider.enabled = enabled;
		}
	}
	*/
}