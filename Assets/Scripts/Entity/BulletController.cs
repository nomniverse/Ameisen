using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public int damage = 1;
    public float range = 20f;
    public float speed = 2000.0f;

    private Vector3 bulletPosition;
    private Vector3 targetPosition;

    public bool foundEnemy = false;

    private int count;

	// Use this for initialization
	void Start () {
        bulletPosition = transform.position;
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;
        this.GetComponent<Rigidbody2D>().velocity = (targetPosition - bulletPosition) * speed;
    }

	// Update is called once per frame
	void Update () {
        if (Mathf.Sqrt(((transform.position.x - bulletPosition.x) * (transform.position.x - bulletPosition.x)) + 
            ((transform.position.y - bulletPosition.y) * (transform.position.y - bulletPosition.y))) >= range)
        {
            Destroy(this.gameObject);
        }
    }

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag.Equals ("Hostile")) {
            other.transform.GetComponent<ZombieController>().TakeDamage(5);
            Destroy(this.gameObject);
        } else if (other.gameObject.tag.Equals("Block"))
        {
            Destroy(this.gameObject);
        } else { }
	}
}
