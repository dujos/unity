using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour {
	private Rigidbody2D[] bodies;
	private float alpha;
	private float offset;

	public void Awake () {
		alpha = 1f;
		offset = 0.2f;
	}

	// Use this for initialization
	void Start () {
		bodies = gameObject.GetComponentsInChildren<Rigidbody2D> ();

		SpriteRenderer[] renderers = gameObject.GetComponentsInChildren<SpriteRenderer> ();
		foreach (SpriteRenderer sr in renderers) {
			sr.color = new Color (1f, 1f, 1f, alpha);
			alpha -= 0.2f;
		}

		for (int i = 0; i < gameObject.transform.childCount; i++) {
			float temp = offset * i;
			transform.GetChild (i).position = transform.GetChild (i).position - new Vector3 (temp, 0, 0);
		}
	}

	// Update is called once per frame
	public void Update () {
		for (int i = 0; i < gameObject.transform.childCount; i++) {
			Vector2 currentPosition = new Vector2 (transform.GetChild(i).position.x, 
			                                       transform.GetChild(i).position.y);
			Vector2 movement = Vector3.right * Time.deltaTime;
			bodies[i].MovePosition (currentPosition + movement);
		}
	}
}