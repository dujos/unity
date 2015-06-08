using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {
	private List<Vector3> _points;

	public List<Vector3> Points {
		get { return _points; }
		set { _points = value; }
	}

	public void Awake () {
		Points = new List<Vector3> ();
		foreach (Transform tr in transform.GetComponentsInChildren<Transform> ()) {
			if (tr.position != transform.position) {
				Points.Add (tr.position);
			}
		}
	}

	public List<Vector3> OffsetPoints (Transform pos) {
		List<Vector3> temp = new List<Vector3> ();

		for (int i = 0; i < Points.Count; i++) {
			temp.Add (Points[i] - pos.position);
		}
		Points = temp;
		return Points;
	}
}