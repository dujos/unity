using UnityEngine;
using System.Collections;

public class Root : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float alpha = 1f;
		SpriteRenderer[] renderers = gameObject.GetComponentsInChildren<SpriteRenderer> ();
		foreach (SpriteRenderer sr in renderers) {
			sr.color = new Color (1f, 1f, 1f, alpha);
			alpha -= 0.2f;
		}
	}
	
	// Update is called once per frame
	public void Update () {
	//float y = (int)AmountToMove.y == 0 ? 0 : -AmountToMove.y;
	//float distanceFactor = 0.05f;

		Debug.Log (gameObject.transform.childCount);
		Debug.Log ("xxx");


		//for (int i = 0; i < GhostingRoot.childCount; ++i) {
			//Vector3 ghostSpriteLocalPos = Vector3.Lerp(GhostingRoot.GetChild(i).localPosition, new Vector3((-CurrentSpeed * distanceFactor * i), (y * distanceFactor * i), 0), 10f * Time.deltaTime);
			//GhostingRoot.GetChild(i).localPosition = ghostSpriteLocalPos;
		//}
	}
}
