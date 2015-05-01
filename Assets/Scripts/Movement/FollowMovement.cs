using UnityEngine;
using System.Collections;

public class FollowMovement : MonoBehaviour {

	public Transform target;
	public Vector3 offset;

	public void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.position = target.position + offset;
	}
}
