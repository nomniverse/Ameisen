using UnityEngine;
using System.Collections;

public class DestroyBlock : MonoBehaviour {

	public float count = 0;
	public float cooldown = 10;
	public bool allowEdit = true;

	public GameObject destroyable;
	Inventory inventory;

	// Use this for initialization
	void Start () {
		inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
		if (count > cooldown) {
			if (Input.GetMouseButton(0) && allowEdit) {
				CastRay();
				count = 0;
			}
		} else {
			count += 1f;
		}
	}

	void CastRay() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
		if (hit) {
			if (hit.collider.gameObject.Equals (destroyable)) {
				Destroy (hit.collider.gameObject);
				inventory.AddItem (3);
			}
		}
	}
}
