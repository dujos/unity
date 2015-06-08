using UnityEngine;
using System.Collections;

public class BarrelBonusWarp : MonoBehaviour {
	public string bonusName;
	public int bonusDuration;

	public void OnTriggerEnter2D (Collider2D collider) {
		if (collider.name == "Kong") {
			Application.LoadLevelAsync (bonusName);
		}
	}
}