using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Numbers : ItemsUI {
	private List<GameObject> digits;
	private string score;

	public void LoadItems (GameObject digit) {
		digits.Add (digit);
	}

	// Use this for initialization
	void Start () {
		digits = new List<GameObject> ();

		/*
		if (score.Length == 1) {
			LoadItems (CreateItems ("FirstDigit", Vector3.one, score.Substring(0)));
			CenterDigits (digits[0]);
		} else {
			LoadItems (CreateItems ("FirstDigit", Vector3.one, score.Substring(0,1)));
			CenterDigits (digits[0]);
			LoadItems (CreateItems ("SecondDigit", Vector3.one, score.Substring(1,1)));
			CenterDigits (digits[1], 2);
		}
		*/
	}
	
	public void CenterDigits (GameObject digit, int offset = 0) {
		Sprite sprite = digit.GetComponent<SpriteRenderer> ().sprite;
		Vector3 center = new Vector3 (0, 0, 0);
		digit.transform.position = center + new Vector3 (offset, 0, 0);
	}
}