using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 1.0f;

	private Vector3 entityPosition;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			rigidbody2D.transform.position += Vector3.up * Time.deltaTime * speed;
		}
		
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			rigidbody2D.transform.position += Vector3.left * Time.deltaTime * speed;
		}
		
		if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
			rigidbody2D.transform.position += Vector3.down * Time.deltaTime * speed;
		}
		
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			rigidbody2D.transform.position += Vector3.right * Time.deltaTime * speed;
		}

		entityPosition = Camera.main.WorldToScreenPoint (transform.position);
		direction = Input.mousePosition - entityPosition;
		rigidbody2D.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg));
	}
}
