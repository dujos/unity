using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathMovement : MonoBehaviour {

	private float duration;
	private int index;
	public List<Transform> points;
	public bool loop;

	public delegate void PathHandlerEnd ();
	public static PathHandlerEnd onPathEnd;

	// Use this for initialization
	public void Start () {
		duration = 1f;
		//loop = true;

		transform.position = points [0].position;
		if (loop) {
			StartCoroutine (MoveOnPathLoop ());
		} else {
			StartCoroutine (MoveOnPath ());
		}
	}

	public int GetPathIndex () {
		return index;
	}

	public void ResetPathIndex () {
		index = 0;
	}

	public IEnumerator MoveOnPath () {
		index = 1;
		while (true) {
			yield return StartCoroutine (transform.MoveTo (points [index].position, duration));
			if (index < points.Count) {
				index++;
				if (index == points.Count) {
					index = points.Count - 1;
					if (onPathEnd != null) {
						onPathEnd ();
					}
				}
			}
		}
	}

	public IEnumerator MoveOnPathLoop () {
		while (true) {
			yield return StartCoroutine (transform.MoveTo (points [index].position, duration));
			index++;
			if (index >= points.Count) {
				index = 1;
				points.Reverse ();
			}
		}
	}
}