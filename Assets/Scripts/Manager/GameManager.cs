using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour {

	public static GameManager gameManager;

	public float coin { get; set; }
	public float token { get; set; }

	private string fileName;

	public void Awake () {
		if (!gameManager) {
			DontDestroyOnLoad (gameObject);
			gameManager = this;
		} else if (gameManager != this) {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		fileName = Application.persistentDataPath + "/kong.gd";
	}

	public void Save () {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (fileName);

		PlayerData data = new PlayerData ();
		data.coin = coin;
		data.token = token;

		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load () {
		if (File.Exists (fileName)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (fileName, FileMode.Open);

			//PlayerData playerData = (PlayerData) bf.Deserialize (file);
			//coin = playerData.coin;
			//token = playerData.token;

			GameObject tnt = (GameObject) bf.Deserialize (file);

			file.Close ();
		}
	}

	public void Reset () {
		coin = 0;
		token = 0;
	}
	
	public void Save (GameObject kong) {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (fileName, FileMode.Open);
		
		bf.Serialize (file, kong);
		file.Close ();
    }
	    
    public void OnGUI () {
		GUI.Label (new Rect (0, 10, 200, 100), "Coin    :    " + coin);
		GUI.Label (new Rect (0, 20, 200, 100), "Token    :  " + token);
	}
}

[System.Serializable]
class PlayerData {

	public float coin;
	public float token;

	public PlayerData () {}
}