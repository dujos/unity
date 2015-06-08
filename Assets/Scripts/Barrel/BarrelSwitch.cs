using UnityEngine;
using System.Collections;

public class BarrelSwitch : MonoBehaviour {

	public GameObject barrel;
	private bool barrelActive;

	// Use this for initialization
	void Start () {
		barrel.SetActive (false);
		barrelActive = false;
	}

	public void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.name == "Kong") {
			if (barrel != null) {
				if (!barrelActive) {
					if (barrel.GetComponent<BarrelDestroy> ()) {
						barrel.GetComponent<BarrelDestroy> ().enabled = true;
						barrel.GetComponent<BarrelActive> ().SetBarrelActive (true);
						barrelActive = true;

						barrel.GetComponent<BarrelDestroy> ().DestroyBarrel ();
					}
				}
			}
		}
	}
}