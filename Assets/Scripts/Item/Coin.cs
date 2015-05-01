using UnityEngine;
using System.Collections;

public class Coin : Entity {
	private int coinPoint;

	public delegate void CoinHandler (int point);
	public static CoinHandler onCoinPicked;

	public void Start () {
		coinPoint = 10;
	}

	public void OnTriggerEnter2D (Collider2D collider) {
		Kong kong = collider.gameObject.GetComponent<Kong> ();
		if (kong) {
			if (onCoinPicked != null) {
				onCoinPicked (coinPoint);
				Destroy (gameObject);
			}
		}
	}
}
