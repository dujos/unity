using UnityEngine;
using System.Collections;

public class RotationBody : MonoBehaviour {
	public static Vector2 NW =  new Vector2 (-0.7f,  0.7f);
	public static Vector2 SW =  new Vector2 (-0.7f, -0.7f);

	public static Vector2 NE =  new Vector2 (0.7f,  0.7f);
	public static Vector2 SE =  new Vector2 (0.7f, -0.7f);

	public static Vector2 N =  new Vector2 (0f, 1f);
	public static Vector2 S =  new Vector2 (0f, -1f);

	public static Vector2 E =  new Vector2 (1f, 0f);
	public static Vector2 W =  new Vector2 (-1f, 0f);

	public static Vector2 GetDirection (Transform targetRotation) {
		float angle = targetRotation.eulerAngles.z;
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
	
	public static int GetFixedAngle (Vector2 dir) {
		int offset = -1;
		if (dir == RotationBody.N) {
			offset = 0;
		} else if (dir == RotationBody.S) {
			offset = 180;
		} else if (dir == RotationBody.W) {
			offset = 90;
		} else if (dir == RotationBody.E) {
			offset = 270;
		} else if (dir == RotationBody.NE) {
			offset = 315;
		} else if (dir == RotationBody.SE) {
			offset = 225;
		} else if (dir == RotationBody.NW) {
			offset = 45;
		} else if (dir == RotationBody.SW) {
			offset = 135;
		}
		return offset;
	}

	public float GetCustomAngle (Vector2 dir) {
		return Vector2.Angle (dir, Vector2.up);
	}

	public static int GetAngle (Transform targetRotation) {
		Vector2 dir = RotationBody.GetDirection (targetRotation);
		return GetFixedAngle (dir);
	}
}