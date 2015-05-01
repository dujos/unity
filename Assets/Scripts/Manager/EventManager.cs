using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	public delegate void ClickAction();
	public static event ClickAction OnClicked;

	public delegate void Health();
	public event Health HealthUp;
	public event Health HealthDown;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
