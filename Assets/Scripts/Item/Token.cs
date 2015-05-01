using UnityEngine;
using System.Collections;

public class Token : Entity {
	private int tokenPoint;

	public delegate void TokenHandler (int point);
	public static TokenHandler onTokenPicked;

	private Vector3 axis { get; set; }
	private float speed { get; set; }

	public void Awake () {
		//gameObject.SetActive (false);
	}

	public void Start () {
		tokenPoint = 20;
		speed = 120;
		axis = Vector3.back;
	}

	public void Update () {
		transform.Rotate (axis, speed * Time.deltaTime);
	}

	public void OnTriggerEnter2D (Collider2D collider) {
		Debug.Log ("Enter  token");
		var kong = collider.GetComponent<Kong> ();
		if (kong) {
			if (onTokenPicked != null) {
				onTokenPicked (tokenPoint);
				Destroy (gameObject);
			}
		}
	}
}