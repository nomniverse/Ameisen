using UnityEngine;
using System.Collections;

public class AddBlock : MonoBehaviour {

	// Cooldown on block editing
	public float cooldown = 10;
	private float count = 0;

	// Used for block placement
	public GameObject blockToPlace;
	private Vector3 position;

	// Determines if a block can be placed or manipulated
	public bool allowEdit = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (count > cooldown) {
			if (Input.GetMouseButton(1) && allowEdit) {
				createBlock();
				count = 0;
			}
		} else {
			count += 1f;
		}
	}

	private void createBlock() {
		position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		position.z = 0;
		Instantiate (blockToPlace, position, Quaternion.identity);
	}
}
