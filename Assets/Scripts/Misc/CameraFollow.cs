using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public float xMargin = 1f;
	public float yMargin = 1f;
	public float xSmooth = 8f;
	public float ySmooth = 8f;
	private Vector2 maxXAndY;
	private Vector2 minXAndY;
	
	private GameObject kong;
	public GameObject bounds;
	
	void Awake () {
		kong = GameObject.Find ("Kong");
		//bounds = GameObject.Find ("Bounds");

		if (bounds != null) {
			Vector3 temp;
			temp = bounds.GetComponent<MeshRenderer> ().bounds.max;
			maxXAndY = new Vector2 (temp.x, temp.y);
			temp = bounds.GetComponent<MeshRenderer> ().bounds.min;
			minXAndY = new Vector2 (temp.x, temp.y);
		}
	}

	bool CheckXMargin() {
		return Mathf.Abs(transform.position.x - kong.transform.position.x) > xMargin;
	}
	
	
	bool CheckYMargin() {
		return Mathf.Abs(transform.position.y - kong.transform.position.y) > yMargin;
	}	
	
	public void Update () {
		TrackKong ();
	}

	void TrackKong () {
		var x = transform.position.x;
		var y = transform.position.y;
		
		if(CheckXMargin()) {
			x = Mathf.Lerp(transform.position.x, kong.transform.position.x, xSmooth * Time.deltaTime);
		}

		if(CheckYMargin()) {
			y = Mathf.Lerp(transform.position.y, kong.transform.position.y, ySmooth * Time.deltaTime);            
		}

		if (bounds != null) {
			x = Mathf.Clamp(x, minXAndY.x, maxXAndY.x);
			y = Mathf.Clamp(y, minXAndY.y, maxXAndY.y);
		}        
        transform.position = new Vector3(x, y, transform.position.z);
    }
}