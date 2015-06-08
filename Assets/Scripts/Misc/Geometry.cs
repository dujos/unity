using UnityEngine;
using System.Collections;

public class Geometry : MonoBehaviour {


	public float CheckCollisionSide (Vector2 hit) {
		return Vector2.Angle (hit, Vector2.right);
	}

	public static Vector2 Vec2 (Transform target) {
		return Vec2 (target.position);
	}

	public static Vector2 Vec2 (Vector3 target) {
		return new Vector2 (target.x, target.y);
	}

	public static Vector3 Vec3 (Vector2 target) {
		return new Vector3 (target.x, target.y, 0);
	}

	public static Vector2 Direction (Vector3 source, Vector3 target) {
		Vector3 dir = (source - target).normalized;
		return new Vector2 (dir.x, dir.y);
	}

	public static bool CompareVec2 (Vector2 lh, Vector2 rh) {
		if (lh.x == rh.x && lh.y == rh.y) {
			return true;
		}
		return false;
	}
}