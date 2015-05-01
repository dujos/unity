using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	private Kong kong;

	// Use this for initialization
	void Start () {
		kong = gameObject.GetComponent<Kong> ();
	}
}
