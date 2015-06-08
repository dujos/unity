using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public abstract class State<T> {
	protected StateMachine<T> _machine;		
	protected T _context;
	
	public State () {}

	internal void SetMachineAndContext (StateMachine<T> machine, T context) {
		_machine = machine;
		_context = context;
	}
	
	public virtual void Begin() {}

	public abstract void Update (float deltaTime);
		
	public virtual void End () {}
}
