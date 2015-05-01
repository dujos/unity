using UnityEngine;
using System.Collections;

public class Scroller : MonoBehaviour {
	public float scrollSpeed;
	private Vector2 savedOffset;
	private Renderer renderer;

	// Use this for initialization
	void Start () {
		renderer = gameObject.GetComponent<Renderer> ();
		savedOffset = renderer.sharedMaterial.GetTextureOffset ("_MainTex");
	}
	
	// Update is called once per frame
	void Update () {
		float x = Mathf.Repeat (Time.time * scrollSpeed, 1);
		Vector2 offset = new Vector2 (x, savedOffset.y);
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}

	public void OnDisable () {
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", savedOffset);
	}
}
