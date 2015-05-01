using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BonusKong : MonoBehaviour {

	private Kong kong;
	private float offset;
	public List<GameObject> spritesCompleted;
	public List<GameObject> spritesUnCompleted;

	// Use this for initialization
	void Start () {
		kong = GetComponent<Kong> ();

		/*
		transform.position = kong.transform.position + new Vector3 (0, offset, 0);
		spritesCompleted = GameObject.FindGameObjectsWithTag ("BC").OrderBy (t => t.name).ToList ();
		spritesUnCompleted = GameObject.FindGameObjectsWithTag ("BUn").OrderBy (t => t.name).ToList ();

		for (int i = 0; i < spritesCompleted.Count; i++) {
			spritesCompleted[i].GetComponent<SpriteRenderer> ().enabled = false;
		}

		for (int i = 0; i < spritesUnCompleted.Count; i++) {
			spritesUnCompleted[i].GetComponent<SpriteRenderer> ().enabled = true;
		}
		*/
	}

	public void AddKong (string name) {
		/*
		var spriteComplete = spritesCompleted.Find (t => t.name == name);
		var spriteUnComplete = spritesUnCompleted.Find (t => t.name == name);

		spriteComplete.GetComponent<SpriteRenderer> ().enabled = true;
		spriteUnComplete.GetComponent<SpriteRenderer> ().enabled = false;
		*/
	}

	public void Update () {
		//transform.position = kong.transform.position + new Vector3 (0, offset, 0);
	}
}