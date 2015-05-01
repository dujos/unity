using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public void OnGUI () {

		if (GUI.Button (new Rect (0, 60, 100, 20), "Coin up")) {
			GameManager.gameManager.coin++;
		}

		if (GUI.Button (new Rect (0, 80, 100, 20), "Coin down")) {
			if (GameManager.gameManager.coin > 0) {
				GameManager.gameManager.coin--;
			}
		}

		if (GUI.Button (new Rect (0, 100, 100, 20), "Token up")) {
			GameManager.gameManager.token++;
		}

		if (GUI.Button (new Rect (0, 120, 100, 20), "Token down")) {
			if (GameManager.gameManager.token > 0) {
				GameManager.gameManager.token--;
			}
		}

		if (GUI.Button (new Rect (0, 140, 60, 20), "Reset")) {
			GameManager.gameManager.Reset ();
		}

		if (GUI.Button (new Rect (60, 140, 60, 20), "Save")) {
			GameManager.gameManager.Save ();
		}

		if (GUI.Button (new Rect (120, 140, 60, 20), "Load")) {
			GameManager.gameManager.Load ();
		}
	}
}
