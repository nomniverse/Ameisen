using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
        Vector3 cameraPosition = new Vector3(GetComponent<Transform>().transform.position.x, GetComponent<Transform>().transform.position.y, 0);
        Instantiate(player, cameraPosition, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
