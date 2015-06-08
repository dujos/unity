using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Letters : ItemsUI {
	private Dictionary<char, Sprite> letterToDigits;
	public char[] text;

	// Use this for initialization
	void Start () {
		letterToDigits = new Dictionary<char, Sprite> ();

		text = new char[] {'k', 'e', 'k', 'e', 'c'};

		LoadSprites ();
		for (int i = 0; i < text.Length; i++) {
			LoadLetters (CreateDigit ("letter_" + text [i].ToString (), new Vector3 (4, 4, 4)), text[i]);
		}
	}

	public void LoadSprites () {
		int start = 'a';
		int end = 'z';
		int k = 0;

		for (int i = start; i <= end; i++) {
			letterToDigits.Add ((char) i, sprites["letters_" + k.ToString ()]);
			k++;
		}
	}

	public void LoadLetters (GameObject digit, char target) {
		GameObject letter = Instantiate (GameObject.Find ("Letter"));
		letter.transform.position = transform.position;
		letter.GetComponent<SpriteRenderer> ().sprite = letterToDigits[target];
		letter.transform.parent = gameObject.transform;
	}
}