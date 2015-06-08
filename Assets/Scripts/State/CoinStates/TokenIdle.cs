using UnityEngine;
using System.Collections;

public class TokenIdle : CoinIdle {

	public override void Begin () {
		Debug.Log ("Token Idle");
		base.Begin ();
	}
	
	public override void Update (float deltaTime) {}
	
	public override void End () {

	}
}