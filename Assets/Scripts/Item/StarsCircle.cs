using UnityEngine;
using System.Collections;

public class StarsCircle : MonoBehaviour {
	public GameObject entity;
	public float radius;
	public int stars;
	private float angle = 0;

	public void Awake () {
		radius = radius > 0 ? radius : 2f;
	}

	public void Start () {
		GenerateCircleStars ();
	}

	public void GenerateCircleStars () {
		Vector3 center = transform.position;
		//RotateAroundMovement ram = entity.GetComponent<RotateAroundMovement> ();
		//ram.center = transform;

		for (int i = 0; i < stars; i++) {
			float angle = i * Mathf.PI * 2 / stars;
			center = transform.position + new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle), 0) * radius;
			GenerateEntities (center);
		}
	}

	public void GenerateEntities (Vector3 center) {
		Instantiate (entity, center, Quaternion.identity);
	}
}