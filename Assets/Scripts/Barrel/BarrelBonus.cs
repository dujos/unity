using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class BarrelBonus : MonoBehaviour {
	private List<GameObject> iconTargets;
	private int currentCount;
	private BarrelBonusGenerator bbg;

	private GameObject currentIcon;
	private GameObject targetIcon;

	private MotorStraight motor;
	private bool kongEnterBonusBarrel;

	// Use this for initialization
	void Start () {
		GameObject temp = GameObject.Find ("BarrelBonusGenerator");
		bbg = temp.GetComponent<BarrelBonusGenerator> ();
		iconTargets = bbg.GetIconTargets ();
		currentCount = bbg.CurrentIcon;
		kongEnterBonusBarrel = false;
	}

	public void Update () {
		currentCount = bbg.CurrentIcon;
	}

	public void OnTriggerEnter2D (Collider2D collider) {
		if (!kongEnterBonusBarrel) {
			kongEnterBonusBarrel = true;
			if (collider.name == "Kong") {
				targetIcon = iconTargets[currentCount];
				currentIcon = transform.GetChild (0).gameObject;
				
				string targetIconName = targetIcon.GetComponent<SpriteRenderer> ().sprite.name;
				string currentIconName = currentIcon.GetComponent<SpriteRenderer> ().sprite.name;

				if (targetIconName.Equals(currentIconName)) {
					StartCoroutine (MoveCurrentIconToTargetIcon (() => {
						motor.Stop ();
						currentIcon.GetComponent<MotorStraight> ().enabled = false;
						Destroy (gameObject);
					}));
				} else {
					Debug.Log (" Bonus game End");
				}

				bbg.NextIcon ();
			}
		}
	}

	public IEnumerator MoveCurrentIconToTargetIcon (Action onComplete) {
		motor = currentIcon.AddComponent<MotorStraight> ();
		motor.velocity = new Vector2 (2, 2);
		motor.MoveTowards (Geometry.Vec2 (targetIcon.transform));


		while (targetIcon.transform.position != currentIcon.transform.position) {
			yield return null;
		}
		onComplete ();
	}
}