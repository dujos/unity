using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	private StateMachine<EnemyController> machine;
	protected Rigidbody2D body;
	public Vector2 velocity;

	// Use this for initialization
	void Start () {
		machine = new StateMachine<EnemyController> (this, new EnemyIdle ());
        machine.AddState (new EnemyDie ());

		//body = GetComponent <Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
        machine.Update (Time.deltaTime);
	}
}
