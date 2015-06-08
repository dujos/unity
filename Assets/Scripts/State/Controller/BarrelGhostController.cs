using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider2D))]
public class BarrelGhostController : Controller {
	protected StateMachine<BarrelGhostController> barrelGhostMachine;
	
	public bool lookAt;
	public float wait;
	
	public void Awake () {
		barrelGhostMachine = new StateMachine<BarrelGhostController> (this, new BarrelGhostEmpty ());
		barrelGhostMachine.AddState (new BarrelGhostFull ());
		barrelGhostMachine.AddState (new BarrelGhostShow ());
		barrelGhostMachine.AddState (new BarrelGhostFire ());
	}
	
	void Start () {}
	
	public void Update () {
		barrelGhostMachine.Update (Time.deltaTime);
	}
}