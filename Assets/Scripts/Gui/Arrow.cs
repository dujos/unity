using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	private float waitTime;
	private float angle;

	// Use this for initialization
	void Start () {
		waitTime = 4f;
		angle = 180f;

		ShowArrow ();
		BlinkArrow ();
	}

	public void ArrowVisible (bool visible) {
		transform.gameObject.GetComponent<SpriteRenderer> ().enabled = visible;
	}

	public void ShowArrow () {
		transform.Rotate (Vector3.back, angle);
	}
	
	public void BlinkArrow () {
		StartCoroutine (BlinkArrowCo ());
	}
	
	private IEnumerator BlinkArrowCo () {
		var endTime = Time.time + waitTime;
		while(Time.time < endTime) {
			ArrowVisible (false);
			yield return new WaitForSeconds(0.4f);
			ArrowVisible (true);
			yield return new WaitForSeconds(0.4f);
		}
	}

	public void DestroyArrow () {
		Destroy (gameObject);
	}
}