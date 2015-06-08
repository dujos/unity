using UnityEngine;
using System.Collections;

public class CoinController : Controller {
	protected StateMachine<CoinController> coinMachine;

	// Use this for initialization
	void Start () {
		coinMachine = new StateMachine<CoinController> (this, new TokenIdle ());
		coinMachine.AddState (new CoinIdle ());
	}
}