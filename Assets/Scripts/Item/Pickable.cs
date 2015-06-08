using UnityEngine;
using System.Collections;

public class Pickable : MonoBehaviour {

	public bool isVisible;
	public bool isRotating;
	private bool isPicked;

	public float speed;
	public float torque;
	public Vector3 axis;
	private Rigidbody2D body;
	private Coroutine coroutine;

	//protected delegate void PickableHandler (int point);
	//protected delegate void PickableHandler ();
	//protected PickableHandler onPicked;
	
	public void Start () {
		isPicked = false;
		coroutine = Coroutine.Make (RotateCo ());
		body = gameObject.GetComponent<Rigidbody2D> ();
	}

	public void Update () {
		if (isPicked && !(body.angularVelocity > 0)) {
			DestroyPickable ();
		}
	}
	
	private IEnumerator RotateCo () {
		while (true) {
			transform.Rotate (axis, speed * Time.deltaTime);
			yield return 0;
		}
	}
	
	public void AddTorque (float torque) {
		body.AddTorque (torque, ForceMode2D.Impulse);
	}

	public void DestroyPickable (float destroyTime = 0) {
		if (isPicked) {
			Destroy (gameObject, destroyTime);
		}
	}
}