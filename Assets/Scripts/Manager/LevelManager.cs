using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LevelManager : MonoBehaviour {

	public static LevelManager instance { get; set; }
	private Kong kong;
	
	private List<BarrelCheckPoint> checkPoints;
	private List<TeleportPoint> teleportPoints;
	
	private int currentCheckPoint;
	private int nextCheckPoint;

	private int currentTeleportPointIndex;

	public void Awake () {
		instance = this;
		
		LoadCheckPoints ();
		//LoadTeleportPoints ();


		kong = GameObject.Find ("Kong").GetComponent<Kong> ();		
		if (currentCheckPoint > -1) {
			checkPoints [currentCheckPoint].EnterCheckPoint (kong);
			if (currentCheckPoint < (checkPoints.Count)) {
				nextCheckPoint++;
			}
		}
	}
	
	// Use this for initialization
	void Start () {
		BarrelCheckPoint.onEnterBarrel += IsNextCheckPointReached;
	}

	public void LoadCheckPoints () {
		checkPoints = FindObjectsOfType<BarrelCheckPoint> ().OrderBy (t => t.transform.position.x).ToList ();
		currentCheckPoint = (checkPoints.Count > 0) ? 0 : -1;
		nextCheckPoint = currentCheckPoint;
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
			currentCheckPoint++;
			checkPoints[currentCheckPoint].EnterCheckPoint (kong);
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