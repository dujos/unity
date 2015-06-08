using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sprites {
	public Dictionary<string, List<Sprite>> groupSprites;
	public Dictionary<string, Sprite> ungroupSprites;

	public Sprites () {
		ungroupSprites = new Dictionary<string, Sprite> ();
		groupSprites = new Dictionary<string, List<Sprite>> ();
		LoadAllSprites ("Textures");
	}

	public void LoadAllSprites (string spritePath) {
		foreach (Sprite sprite in Resources.LoadAll<Sprite> (spritePath)) {
			ungroupSprites.Add (sprite.name, sprite);
		}
	}

	public void LoadSprites (string spritePath) {
		if (!groupSprites.ContainsKey (spritePath)) {
			List<Sprite> temp = new List<Sprite> ();
			foreach (Sprite sprite in Resources.LoadAll<Sprite> (spritePath)) {
				temp.Add (sprite);
			}
			groupSprites.Add (spritePath, temp);
		}
	}

	public List<Sprite> GetSprites (string path) {
		if (groupSprites.ContainsKey (path)) {
			return groupSprites[path];
		}
		return null;
	}
}