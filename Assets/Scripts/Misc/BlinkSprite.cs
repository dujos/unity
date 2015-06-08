using UnityEngine;
using System.Collections;

public class BlinkSprite : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (Blink (1f, 10, new Color (1,1,1,1)));
	}

	public IEnumerator Blink (float delayBetweenBlinks, int numOfBlinks, Color blinkColor) {
		Material material = GetComponent<SpriteRenderer> ().material;
		int counter = 0;

		while (counter < numOfBlinks) {
			material.SetColor ("_BlinkColor", blinkColor);
			counter++;
			blinkColor.a = blinkColor.a == 1f ? 0f : 1f;
			yield return new WaitForSeconds( delayBetweenBlinks );
		}

		blinkColor.a = 0f;
		material.SetColor ("_BlinkColor", blinkColor);
	}

	IEnumerator BlinkSmooth (float timeScale, float duration, Color blinkColor) {
		var material = GetComponent<SpriteRenderer>().material;
		var elapsedTime = 0f;
		while (elapsedTime <= duration) {
			material.SetColor ("_BlinkColor", blinkColor);
			
			blinkColor.a = Mathf.PingPong (elapsedTime * timeScale, 1f);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		
		blinkColor.a = 0f;
		material.SetColor ("_BlinkColor", blinkColor);
	}
}