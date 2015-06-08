using UnityEngine;
using System.Collections;

public class DataBase : MonoBehaviour {
	public string name;
	public int score;
	public string[] topScores;
	public string dbUrl= "http://localhost/unity_tut/";

	// Use this for initialization
	void Start () {
	
	}

	public void SaveScores () {
		StartCoroutine(SaveScoresCo ());
	}

	public void LoadScores () {
		StartCoroutine(LoadScoresCo ());
	}

	IEnumerator SaveScoresCo () {
		WWWForm form = new WWWForm();

		form.AddField("Name", name);
		form.AddField("Score", score);
		
		WWW webRequest = new WWW(dbUrl + "SaveScore.php", form);		
		yield return webRequest;
	}

	IEnumerator LoadScoresCo () {
		WWW webRequest = new WWW(dbUrl + "LoadScore.php");
		yield return webRequest;
	}
}