using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {

	public List<Transform> points;

	// Use this for initialization
	void Start () {
		points = new List<Transform> ();
	}
}
