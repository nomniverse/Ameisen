using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public int damage = 1;
    public int range = 20;
    public float speed = 2000000000000.0f;

    private Vector3 bulletPosition;
    private Vector3 targetPosition;

    public bool foundEnemy = false;

	// Use this for initialization
	void Start () {
        bulletPosition = transform.position;
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;
        Destroy(this.gameObject, range);
    }

	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag.Equals ("Hostile")) {
            other.transform.GetComponent<ZombieController>().TakeDamage(5);
            Destroy(this.gameObject);
        }
	}
}
