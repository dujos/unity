using UnityEngine;
using System.Collections;

public class MotorCamera : MonoBehaviour {
	public float smooth = 1.5f;         // The relative speed at which the camera will catch up.
	private Transform kong;           	// Reference to the player's transform.
	private Vector3 relCameraPos;       // The relative position of the camera from the player.
	private float relCameraPosMag;      // The distance of the camera from the player.
	private Vector3 newPos;             // The position the camera is trying to reach

	void Awake () {
		kong = GameObject.Find("Kong").transform;
		relCameraPos = transform.position - kong.position;
		relCameraPosMag = relCameraPos.magnitude - 0.5f;
	}

	public void Start () {
		Detector.OnDetectedOn += ActivateScript;
		Detector.OnDetectedOff += DeActivateScript;
	}

	public void OnDisable () {
		Detector.OnDetectedOn -= ActivateScript;
		Detector.OnDetectedOff -= DeActivateScript;
	}

	public void ActivateScript () {
		GetComponent<MotorCamera> ().enabled = false;
	}

	public void DeActivateScript () {
		GetComponent<MotorCamera> ().enabled = true;
	}

	void FixedUpdate () {
		Vector3 standardPos = kong.position + relCameraPos;
		Vector3 abovePos = kong.position + Vector3.up * relCameraPosMag;
		Vector3[] checkPoints = new Vector3[5];

		checkPoints[0] = standardPos;		
		checkPoints[1] = Vector3.Lerp(standardPos, abovePos, 0.25f);
		checkPoints[2] = Vector3.Lerp(standardPos, abovePos, 0.5f);
		checkPoints[3] = Vector3.Lerp(standardPos, abovePos, 0.75f);		
		checkPoints[4] = abovePos;
		
		for(int i = 0; i < checkPoints.Length; i++) {
			if(ViewingPosCheck(checkPoints[i])) {
				break;
			}
		}
		transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
		SmoothLookAt();
	}
	
	
	bool ViewingPosCheck (Vector3 checkPos) {
		RaycastHit hit;
		if(Physics.Raycast(checkPos, kong.position - checkPos, out hit, relCameraPosMag)) {
			if(hit.transform != kong) {
				return false;
			}
		}
		newPos = checkPos;
		return true;
	}
	
	
	void SmoothLookAt () {
		Vector3 relPlayerPosition = kong.position - transform.position;
		Quaternion lookAtRotation = Quaternion.LookRotation(relPlayerPosition, Vector3.up);
	}
}