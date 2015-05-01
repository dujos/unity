using UnityEngine;
using System.Collections;

public class BarrelKong : Barrel {

	public void OnMouseDown () {
		if (isKongInside) {
			kong.KongExitBarrel (transform);
		}
	}
}
