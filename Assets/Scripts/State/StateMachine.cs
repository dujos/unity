using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public sealed class StateMachine<T> {
	protected T _context;
	protected float durationInState = 0f;		
	private Dictionary<System.Type, State<T>> _states = new Dictionary<System.Type, State<T>> ();
	
	public event Action onStateChanged;

	protected State<T> currentState;
	protected State<T> previousState;

	public StateMachine (T context, State<T> state) {
		this._context = context;

		if(_states == null) {
			_states = new Dictionary<System.Type, State<T>> ();
		}

		AddState (state);
		currentState = state;
		currentState.Begin ();
	}

	public string GetCurrentStateName () {
		return currentState.ToString ();
	}

	public State<T> CurrentState () {
		return currentState;
	}

	public void AddState (State<T> state) {
		state.SetMachineAndContext (this, _context);
		_states[state.GetType()] = state;
	}

	public void Update (float deltaTime) {
		durationInState += deltaTime;
		currentState.Update (deltaTime);
	}

	public R ChangeState<R> () where R : State<T> {
		var state = typeof (R);
		if(currentState.GetType() == state) {
			return currentState as R;
		}

		if (currentState != null) {
			currentState.End();
		}

		previousState = currentState;
		currentState = _states[state];
		currentState.Begin ();
		durationInState = 0f;

		if(onStateChanged != null) {
			onStateChanged();
		}

		return currentState as R;
	}
}