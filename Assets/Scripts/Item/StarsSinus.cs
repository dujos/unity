using UnityEngine;
using System.Collections;

public class StarsSinus : MonoBehaviour {
	public GameObject star;
	public int stars;
	public float offset;

	public enum State {Sinus, Cosinus};
	public State state;

	// Use this for initialization
	void Start () {
		GenerateSinusPathStars ();
	}

	public void GenerateSinusPathStars () {
		for (int i = 0; i < stars; i++) {
			//float angle = i * Mathf.PI * 2 / stars;
			float angle = i * 360 / stars;
			if (state == State.Sinus) {
				transform.position += new Vector3 (offset, Mathf.Sin (angle), 0);
			} else if (state == State.Cosinus) {
				transform.position += new Vector3 (offset, Mathf.Cos (angle), 0);
			}
			Instantiate (star, transform.position, Quaternion.identity);
		}
	}
}