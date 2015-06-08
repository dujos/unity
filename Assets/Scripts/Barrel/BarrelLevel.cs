using UnityEngine;
using System.Collections;

public class BarrelLevel : MonoBehaviour {
	public string levelName;

	public void OnTriggerEnter2D (Collider2D collider) {
		if (collider.name == "Kong") {
			Application.LoadLevelAsync (levelName);
		}
	}
}
