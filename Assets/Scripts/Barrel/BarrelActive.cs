using UnityEngine;
using System.Collections;

public class BarrelActive : MonoBehaviour {
	
	public void SetBarrelActive (bool active) {
		gameObject.SetActive (active);
	}
}
