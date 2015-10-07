using UnityEngine;
using System.Collections;

public class LevelTrigger : MonoBehaviour {

	public GameObject target;
	public string level;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			GoToLevel (level);
		}
	}
	
	public void GoToLevel(string level) {
		Application.LoadLevel(level);
	}
}
