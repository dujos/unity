using UnityEngine;
using System.Collections;

public class Boost : MonoBehaviour {

	public delegate void BoostHandler(GameObject other);
	public static BoostHandler onPickedBoost;
	public static BoostHandler onRemoveBoost;
}
