using UnityEngine;
using System.Collections;

public class StarsLine : MonoBehaviour {
	public GameObject star;
	public Vector2 offset;
	public Vector2 distance;
	public bool moving;
	public int stars;

	public void Start () {
		GenerateLineStars ();
	}

	public void GenerateLineStars () {
		Vector3 center = transform.position;
		for (int i = 0; i < stars; i++) {
			center += new Vector3 (offset.x, offset.y, 0);
			Instantiate (star, center, Quaternion.identity);
		}
	}

	
	public void GenerateMovingLineStars () {
		Vector3 center = transform.position;
		for (int i = 0; i < stars; i++) {
			center += new Vector3 (offset.x, offset.y, 0);
			Instantiate (star, center, Quaternion.identity);
			
			//star.GetComponent<StraightWaveMovement> ().start = center;
			//star.GetComponent<StraightWaveMovement> ().target = center + new Vector3 (distance.x, distance.y, 0);
		}
	}
}