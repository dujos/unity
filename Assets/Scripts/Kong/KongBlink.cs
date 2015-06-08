using UnityEngine;
using System.Collections;

public class KongBlink : MonoBehaviour {
	private float duration = 4f;
	private float waitDuration = 0f;
	private float currentRate = 0f;
	private float fireRate = 0.1f;
	private SpriteRenderer spriteRender;

	// Use this for initialization
	void Start () {
		spriteRender = GetComponent<SpriteRenderer> ();
		InvokeRepeating("Blink", waitDuration, fireRate);
	}

	public void SetBlinkDuration (float duration, float waitDuration, float fireRate) {
		this.duration = duration;
		this.waitDuration = waitDuration;
		this.fireRate = fireRate;
	}

	public void Blink() {
		 currentRate += fireRate;
		if (spriteRender.enabled == true) {
			spriteRender.enabled = false;
		} else {
			spriteRender.enabled = true;
		}
	}

	public void Update () {
		if (currentRate > duration) {
			spriteRender.enabled = true;
			CancelInvoke ("Blink");
		}
	}
}