using UnityEngine;
using System.Collections;

public class StarsTriangle : MonoBehaviour {
	public GameObject star;
	public float xOffset;
	public float yOffset;
	public int stars;
	public int height;

	// Use this for initialization
	void Start () {
		GenerateTriangleStars ();
	}

	public void GenerateTriangleStars () {
		Vector3 center = transform.position;
		for (int j = 0; j < height; j++) {
			center.y += yOffset;
			center.x = transform.position.x;
			for (int i = 0; i < stars; i++) {
				center.x += xOffset;
				Instantiate (star, center, Quaternion.identity);
			}
		}
	}
}
