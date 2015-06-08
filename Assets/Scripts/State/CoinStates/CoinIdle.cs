using UnityEngine;
using System.Collections;

public class CoinIdle : State<CoinController> {

	public override void Begin () {
		Debug.Log ("Coin idle");
	}
	
	public override void Update (float deltaTime) {}
	
	public override void End () {}
}