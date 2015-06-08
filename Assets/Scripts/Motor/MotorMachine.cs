using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MotorMachine<T> {
	protected T _context;

	public MotorMachine (T grr) {
		_context = grr;
	}

	/*
	private Dictionary<System.Type, Motor<T>> _motors = new Dictionary<System.Type, Motor<T>> ();

	protected Motor<T> currentMotor;
	protected Motor<T> previousMotor;

	public MotorMachine (T context, Motor<T> motor) {
		this._context = context;
		
		if (_motors == null) {
			_motors = new Dictionary<System.Type, T> ();
		}
		
		AddMotor (motor);
		currentMotor = motor;
	}
	
	public void AddMotor (T motor) {
		_motors[motor.GetType()] = motor;
	}
	*/
}
