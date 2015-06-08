using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoroutineManager : MonoBehaviour {
	static CoroutineManager _instance = null;

	public static CoroutineManager Instance {
		get {
			if (!_instance) {
				_instance = FindObjectOfType (typeof (CoroutineManager)) as CoroutineManager;

				if (!_instance) {
					var go = new GameObject ("CoroutineManager");
					_instance = go.AddComponent<CoroutineManager> ();
				}
			}
			return _instance;
		}
	}

	public void OnApplicationQuit () {
		_instance = null;
	}
}

public class Coroutine {
	public event System.Action<bool> onComplete;

	private bool _running;
	public bool Running { get {return _running; } }

	private bool _pause;
	public bool Pause { get {return _pause; } }

	private IEnumerator _coroutine;
	private bool _coroutineKilled;
	//private Stack<Coroutine> _childCoroutines;

	public Coroutine (IEnumerator coroutine) : this (coroutine, false) {}

	public Coroutine (IEnumerator coroutine, bool forceStart) {
		_coroutine = coroutine;
		if (forceStart) {
			Start ();
		}
	}

	public static Coroutine Make (IEnumerator coroutine) {
		return new Coroutine (coroutine);
	}

	public static Coroutine Make (IEnumerator coroutine, bool forceStart) {
		return new Coroutine (coroutine, forceStart);
	}

	public void Start () {
		_running = true;
		CoroutineManager.Instance.StartCoroutine (DoCoroutine ());
	}
	
	public IEnumerator StartAsCoroutine () {
		_running = true;
		yield return CoroutineManager.Instance.StartCoroutine (DoCoroutine ());
	}
	
	public void StartPause () {
		_pause = true;
	}
	
	public void StopPause () {
		_pause = false;
	}
	
	public void KillCoroutine () {
		_coroutineKilled = true;
		_running = false;
		_pause = false;
	}
	
	public void KillCoroutine (float wait) {
		var delay = (int)(wait * 1000);
		new System.Threading.Timer (obj => {
			lock (this) {
				KillCoroutine ();
			}
		}, null, delay, System.Threading.Timeout.Infinite);
	}
	
	public IEnumerator DoCoroutine () {
		yield return null;
		
		while (_running) {
			if (_pause) {
				yield return null;
			} else {
				if (_coroutine.MoveNext ()) {
					yield return _coroutine.Current;
				} else {
					//if (_childCoroutines != null) {
					//	yield return CoroutineManager.Instance.StartCoroutine (RunChildCoroutines ());
					//}
					_running = false;
				}
			}
			
			if (onComplete != null) {
				onComplete (_coroutineKilled);
			}
		}
	}

	/*
	public Coroutine createAndAddChildCoroutine (IEnumerator coroutine, bool forceStart) {
		var temp = new Coroutine (coroutine, forceStart);
		AddChildCoroutine (temp);
		return temp;
	}

	public void AddChildCoroutine (Coroutine coroutine) {
		if (_childCoroutines != null) {
			_childCoroutines = new Stack<Coroutine> ();
		}
		_childCoroutines.Push (coroutine);
	}

	public void RemoveChildCoroutine (Coroutine coroutine) {
		if (_childCoroutines.Contains (coroutine)) {
			_childCoroutines.Pop ();
		}
	}
	
	private IEnumerator RunChildCoroutines () {
		if (_childCoroutines != null && _childCoroutines.Count > 0) {
			do {
				Coroutine childCoroutine = _childCoroutines.Pop ();
				yield return CoroutineManager.Instance.StartCoroutine (childCoroutine.StartAsCoroutine ());
			} while (_childCoroutines > 0);
		}
	}
	*/
}