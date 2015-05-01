using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	private int coinScore;
	private int tokenScore;
	private int starScore;
	private GameObject kong;

	// Use this for initialization
	void Start () {
		coinScore = 0;
		tokenScore = 0;
		starScore = 0;

		Coin.onCoinPicked += CoinPicked;
		Token.onTokenPicked += TokenPicked;

		kong = GameObject.Find ("Kong");
	}

	public void CoinPicked (int point) {
		coinScore += point;
	}

	public void TokenPicked (int point) {
		tokenScore += point;
	}

	public void Update () {

	}

	public void OnGui () {

	}
}