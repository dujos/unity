using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour {

	public static DrawLine instance;

	public Transform start;
	public Transform target;

	public void Start () {
		instance = this;
	}

	public void OnDrawGizmos () {
		Gizmos.DrawLine (start.position, target.position);
    }
}
