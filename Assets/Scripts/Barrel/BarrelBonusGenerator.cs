using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BarrelBonusGenerator : MonoBehaviour {
	public Vector3 position;
	public Vector2 offset;
	public float iconOffset;

	public enum BarrelType { BarrelOil = 0, BarrelMold = 1, BarrelNormal = 2 }
	public BarrelType barrelType;
	public enum IconType { Balloons = 0, Kongs = 1 }
	public IconType iconType;

	private List<GameObject> barrelBonuses;
	private List<GameObject> iconTargets;
	private List<Sprite> iconSprites;
	private Sprites sprites;

	public int _currentIcon;

	public int CurrentIcon {
		get { return _currentIcon; }
		set { _currentIcon = value; }
	}

	public void OnAwake () {
		_currentIcon = 0;
	}

	// Use this for initialization
	void Start () {
		sprites = new Sprites ();
		iconSprites = new List<Sprite> ();
		barrelBonuses = new List<GameObject> ();
		iconTargets = new List<GameObject> ();

		string path = "Textures/barrelBonus";
		LoadBarrels (path);
		GenerateTargetOrder ();
	}

	public void LoadBarrels (string path) {
		sprites.LoadSprites (path);

		Sprite barrelSprite = null;
		if (BarrelType.BarrelOil == barrelType) {
			barrelSprite = sprites.GetSprites (path)[0];
		} else if (BarrelType.BarrelMold == barrelType) {
			barrelSprite = sprites.GetSprites (path)[1];
		} else if (BarrelType.BarrelNormal == barrelType) {
			barrelSprite = sprites.GetSprites (path)[2];
		}

		if (IconType.Balloons == iconType) {
			string iconPath = "Textures/balloons";
			sprites.LoadSprites (iconPath);
			iconSprites = sprites.GetSprites (iconPath);
		} else if (IconType.Kongs == iconType) {
			string iconPath = "Textures/kongs";
			sprites.LoadSprites (iconPath);
			iconSprites = sprites.GetSprites (iconPath);
		}

		List<int> temp = Shuffle (iconSprites.Count);
		
		for (int i = 0; i < iconSprites.Count; i++) {
			GameObject bb = new GameObject (string.Concat ("BarrelBonus ", i.ToString()));
			bb.AddComponent<BarrelBonus> ();
			bb.AddComponent<SpriteRenderer> ();
			bb.GetComponent<SpriteRenderer> ().sprite = barrelSprite;
			bb.AddComponent<CircleCollider2D> ().isTrigger = true;

			bb.transform.localScale = new Vector3 (3, 3, 3);
			bb.transform.position = position + new Vector3 (offset.x * i, offset.y * i, 0);

			GameObject icon = new GameObject (string.Concat ("Icon ", i.ToString()));
			icon.AddComponent<SpriteRenderer> ();
			icon.GetComponent<SpriteRenderer> ().sprite = iconSprites[temp[i]];
			icon.transform.parent = bb.transform;
			icon.transform.localScale = new Vector3 (1, 1, 1);
			icon.transform.position = bb.transform.position;

			barrelBonuses.Add (bb);
		}
	}

	public void GenerateTargetOrder () {
		for (int i = 0; i < iconSprites.Count; i++) {
			GameObject icon = new GameObject (string.Concat ("Icon Order ", i.ToString()));
			icon.AddComponent<SpriteRenderer> ();
			icon.GetComponent<SpriteRenderer> ().sprite = iconSprites[i];
			icon.transform.localScale = new Vector3 (3, 3, 3);

			if (offset.y > 0) {
				icon.transform.position = position + new Vector3 ((offset.y * i), iconOffset, 0);
			} else {
				icon.transform.position = position + new Vector3 (offset.x * i, (offset.y * i) + iconOffset, 0);
			}
			iconTargets.Add (icon);
		}
	}

	public void CreateTargetIcon () {

	}

	public void NextIcon () {
		if (CurrentIcon < iconTargets.Count) {
			CurrentIcon++;
			if (CurrentIcon == iconTargets.Count) {
				Debug.Log ("Bonus Barrel Game Victory");
			}
		}
	}

	public List<GameObject> GetIconTargets () {
		return iconTargets;
	}

	public List<int> Shuffle (int length) {
		List<int> set = new List<int> ();

		do {
			int count = Random.Range (0, length);
			if (!set.Exists (t => t == count)) {
				set.Add (count);
			}
		} while (set.Count < length);

		return set;
	}
}
