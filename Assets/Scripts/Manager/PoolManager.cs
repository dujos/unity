using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour {
	public static List<PoolModel> pool = new List<PoolModel> ();

	public class PoolModel {
		public GameObject prefab;
		public string prefabName;
		public ArrayList all;
		public Stack available;
	}

	public static PoolModel AddPoolModel (GameObject prefab, uint capacity) {
		PoolModel poolModel = new PoolModel ();
		
		poolModel.prefab = prefab;
		poolModel.prefabName = prefab.name + "(Clone)";
		poolModel.all = (capacity > 0) ? new ArrayList((int) capacity) : new ArrayList();
		poolModel.available = (capacity > 0) ? new Stack((int) capacity) : new Stack();
		pool.Add (poolModel);

		return poolModel;
	}
	
	private static int NumActive (GameObject prefab) {
		PoolModel poolModel = GetPoolModelByPrefab(prefab);
		
		if(poolModel == null) {
			return 0;
		} else {
			return poolModel.all.Count - poolModel.available.Count;
		}
	}
	
	private static int NumAvailable (GameObject prefab) {
		PoolModel poolModel = GetPoolModelByPrefab(prefab);

		if(poolModel == null) {
			return 0;
		} else {
			return poolModel.available.Count;
		}
	}
	
	public static GameObject Spawn (GameObject prefab, Vector3 position, Quaternion rotation) {
		GameObject result;
		PoolModel currentPoolModel = new PoolModel();
		
		if(DoesPoolModelExist(prefab)) {
			currentPoolModel = GetPoolModelByPrefab (prefab);
		} else {
			currentPoolModel = AddPoolModel (prefab, 10);
		}
		
		if (currentPoolModel.available.Count == 0) {
			result = GameObject.Instantiate (prefab, position, rotation) as GameObject;
			currentPoolModel.all.Add(result);

		} else {
			result = currentPoolModel.available.Pop() as GameObject;
			if(result == null) {
				result = GameObject.Instantiate (prefab, position, rotation) as GameObject;
			}
			
			Transform resultTrans = result.transform;
			resultTrans.position = position;
			resultTrans.rotation = rotation;
			
			SetActive (result, true);
		}
		return result;
	}
	
	public static bool DestroyPrefab (GameObject target) {
		PoolModel currentPoolModel = GetPoolModelByPrefab (target);

		if(DoesPoolModelExist (target)) {
			if (!currentPoolModel.available.Contains (target)) {
				currentPoolModel.available.Push (target);

				SetActive(target, false);
				return true;
			}
		} else {

			Destroy(target);
			return true;
		}
		return false;
	}

	public static void DestroyAll () {
		foreach(PoolModel poolModel in pool) {
			for (int i = 0; i < poolModel.all.Count; i++) {
				GameObject target = poolModel.all[i] as GameObject;
				
				if (target.active) {
					Destroy(target);
				}
			}
		}
	}

	public static void Clear() {
		DestroyAll();

		foreach (PoolModel poolModel in pool) {
			poolModel.available.Clear();
			poolModel.all.Clear();
		}
	}
	
	public static bool DoesPoolModelExist (GameObject prefab) {
		bool prefabExists = false;
		string prefabName;

		if(prefab.name.Contains("(Clone)")) {
			prefabName = prefab.name;
		} else {
			prefabName = prefab.name + "(Clone)";
		}

		foreach (PoolModel poolModel in pool) {
			if (poolModel.prefabName == prefabName) {
				prefabExists = true;
			}
		}
		return prefabExists;
	}
	
	protected static void SetActive(GameObject target, bool active) {
		RecursiveDeepActivation(target.transform, active);
	}
	
	protected static PoolModel GetPoolModelByPrefab(GameObject prefab) {
		string prefabName;
		
		if (prefab.name.Contains("(Clone)")) {
			prefabName = prefab.name;
		} else {
			prefabName = prefab.name + "(Clone)";
		}

		PoolModel result = new PoolModel();
		foreach(PoolModel poolModel in pool) {
			if (poolModel.prefabName == prefabName) {
				result = poolModel;
			}
		}
		
		return result;
	}
	
	protected static void RecursiveDeepActivation (Transform gameObjectTransform, bool activate) {
		foreach (Transform t in gameObjectTransform) {
			RecursiveDeepActivation (t, activate);
		}
		gameObjectTransform.gameObject.active = activate;
	}
}