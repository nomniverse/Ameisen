using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	private Vector3 direction;

	public GameObject shooter;

	public float speed;

	Ray ray;

	// Use this for initialization
	void Start () {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		direction = shooter.GetComponent<PlayerController>().rotation;
	}

	// Update is called once per frame
	void Update () {
		transform.position += ray.direction * Time.deltaTime * speed;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag.Equals ("Hostile")) {
			Destroy (other.gameObject);
			Destroy (this);
		}
	}
}
