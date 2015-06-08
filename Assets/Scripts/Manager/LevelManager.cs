using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LevelManager : MonoBehaviour {
	public static LevelManager instance;
	private Kong kong;
	private Score score;

	private List<BarrelCheckPoint> checkPoints;
	private List<TeleportPoint> teleportPoints;
	private List<BarrelBonusWarp> bonusPoints;

	private BarrelLevel barrelLevel;
	
	private int currentCheckPoint;
	private int nextCheckPoint;
	private int currentTeleportPointIndex;

	public enum Location {
		World, Level, Bonus
	};

	private Location currentLocation;

	public void Awake () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	LevelManager Instance {
		get {
			if (instance == null) {
				GameObject levelManager = GameObject.Find ("BarrelLevel");
				instance = levelManager.GetComponent<LevelManager> ();
			}
			return instance;
		}
	}
	
	// Use this for initialization
	void Start () {
		LoadCheckPoints ();
		//LoadTeleportPoints ();
		LoadLevels ();
		LoadBonusPoints ();


		score = GameObject.Find ("Score").GetComponent<Score> ();
		kong = GameObject.Find ("Kong").GetComponent<Kong> ();

		EnterCheckPoint ();
	}

	public void SetLocation (Location location) {
		currentLocation = location;
	}

	private void LoadBonusPoints () {
		bonusPoints = FindObjectsOfType<BarrelBonusWarp> ().ToList ();
	}

	private void LoadLevels () {
		barrelLevel = GameObject.Find ("BarrelLevel").GetComponent<BarrelLevel> ();
	}

	public void LoadCheckPoints () {
		checkPoints = FindObjectsOfType<BarrelCheckPoint> ().OrderBy (t => t.transform.position.x).ToList ();
		currentCheckPoint = (checkPoints.Count > 0) ? 0 : -1;
		nextCheckPoint = currentCheckPoint;
	}

	public void EnterCheckPoint () {
		if (currentCheckPoint > -1) {
			if (!checkPoints [currentCheckPoint].IsVisited ()) {
				checkPoints [currentCheckPoint].EnterCheckPoint (kong);
			}
			if (currentCheckPoint < (checkPoints.Count)) {
				nextCheckPoint++;
			}
		}
		BarrelCheckPoint.onEnterBarrel += IsNextCheckPointReached;
	}

	private void IsNextCheckPointReached () {
		if (nextCheckPoint < checkPoints.Count) {
			float current = checkPoints[currentCheckPoint].transform.position.x;
			float next = checkPoints[nextCheckPoint].transform.position.x;
			float distanceToCheckPoint = current - next;
			if (distanceToCheckPoint < 0) {
				NextCheckPointReached ();
			}
		}
	}
	
	public void NextCheckPointReached () {
		if (nextCheckPoint > currentCheckPoint) {
			checkPoints[currentCheckPoint].ExitCheckPoint ();
			currentCheckPoint++;

			if (!checkPoints [currentCheckPoint].IsVisited ()) {
				checkPoints[currentCheckPoint].EnterCheckPoint (kong);
			}

			if (nextCheckPoint < checkPoints.Count) {
				nextCheckPoint++;
			}
		}
	}

	public void LoadTeleportPoints () {
		teleportPoints = FindObjectsOfType<TeleportPoint> ().ToList();

		for (int i = 0; i < teleportPoints.Count; i++) {
			TeleportPoint teleport = teleportPoints[i];
			if (teleport != null) {
				if ((i + 1) < teleportPoints.Count) {
					teleport.next = teleportPoints[i++];
				}
			}
		}
	}
}