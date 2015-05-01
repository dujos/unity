using UnityEngine;
using System.Collections;

public class RotateAroundMovement : MonoBehaviour {
	public float speed;
	public Transform center;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.RotateAround (center.position, Vector3.back, speed * Time.deltaTime);
	}
}