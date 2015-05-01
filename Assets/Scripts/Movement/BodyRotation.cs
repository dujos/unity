using UnityEngine;
using System.Collections;

public class BodyRotation : MonoBehaviour {

	public static Vector2 NW =  new Vector2 (-1, 1);
	public static Vector2 SW =  new Vector2 (-1, -1);

	public static Vector2 NE =  new Vector2 (1, 1);
	public static Vector2 SE =  new Vector2 (1, -1);

	public static Vector2 N =  new Vector2 (0, 1);
	public static Vector2 S =  new Vector2 (0, -1);

	public static Vector2 E =  new Vector2 (1, 0);
	public static Vector2 W =  new Vector2 (-1, 0);

	public static Vector2 GetDirection (Transform targetRotation) {
		float angle = targetRotation.eulerAngles.z;
		Debug.Log (angle);
		Vector2 kongDirection = Vector2.zero;

		if (angle >= 337.5 || angle < 22.5) {
			kongDirection = N;
		} else if (angle >= 22.5 && angle < 67.5) {
			kongDirection = NW;
		} else if (angle >= 67.5 && angle < 112.5) {
			kongDirection = W;
		} else if (angle >= 112.5 && angle < 157.5) {
			kongDirection = SW;
		} else if (angle >= 157.5 && angle < 202.5) {
			kongDirection = S;
		} else if (angle >= 202.5 && angle < 247.5) {
			kongDirection = SE;
		} else if (angle >= 247.5 && angle < 292.5) {
			kongDirection = E;
		} else if (angle >= 292.5 && angle < 337.5) {
			kongDirection = NE;
		}
		return kongDirection;
	}
}