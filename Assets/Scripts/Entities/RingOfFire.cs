using UnityEngine;
using System.Collections;

public class RingOfFire : MonoBehaviour {
	private Rotate rotate;
	public float duration;
	
	public void Awake () {
		rotate = gameObject.GetComponent<Rotate> ();
	}
	
	public void Start () {
		StartCoroutine (RotateMovementCo ());
	}

	public IEnumerator RotateMovementCo () {
		while (true) {
			transform.Rotate (Vector3.up, 1);
			yield return new WaitForSeconds (duration);
		}
	}
}