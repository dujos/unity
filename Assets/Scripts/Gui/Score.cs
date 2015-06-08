using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Score : MonoBehaviour {
	private int coinScore;
	private int tokenScore;
	private int starScore;
	private GameObject coinNumber;
	private GameObject tokenNumber;
	private GameObject starNumber;
	private List<GameObject>[] scores;

	public void Awake () {
		tokenScore = 0;
		starScore = 0;
	}

	// Use this for initialization
	void Start () {
		/*
		GameObject.Find ("Token").GetComponent<Token> ().onItemPicked += TokenPicked;
		GameObject.Find ("Star").GetComponent<Star> ().onItemPicked += StarPicked;
		GameObject.Find ("Token").GetComponent<Token> ().onItemPicked += TokenStart;

		coinNumber = Instantiate (GameObject.Find ("Numbers"));
		coinNumber.name = "CoinScore";
		starNumber = Instantiate (GameObject.Find ("Numbers"));
		starNumber.name = "StarScore";
		tokenNumber = Instantiate (GameObject.Find ("Numbers"));
		tokenNumber.name = "TokenScore";
		*/
	}

	public void ShowAll () {

	}

	public void ItemShow () {

	}

	public void TokenStart () {}

	public void CoinPicked (int point) {
		coinScore += point;
	}

	public void TokenPicked (int point) {
		tokenScore += point;
	}

	public void StarPicked (int point) {
		starScore += point;
	}
}