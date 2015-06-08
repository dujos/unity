using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemsUI : MonoBehaviour {
	public Dictionary<string, Sprite> sprites;

	public void Awake () {
		sprites = new Dictionary<string, Sprite> ();
		LoadSprites ("Textures");
	}

	public void LoadSprites (string spritePath) {
		foreach (Sprite sprite in Resources.LoadAll<Sprite> (spritePath)) {
			sprites.Add (sprite.name, sprite);
		}
	}
	
	public GameObject CreateDigit (string name, Vector3 scale) {
		GameObject digit = new GameObject ();
		digit.name = name;
		digit.gameObject.transform.localScale = scale;
		return digit;
	}
}