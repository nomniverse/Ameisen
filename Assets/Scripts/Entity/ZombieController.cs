using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

	private float zombieHealth = 100f;

	public float speed = 4.0f;
	public float turnSpeed = 4.0f;

	private Vector3 entityPosition;
	private Vector3 targetPosition;
	private Vector3 direction;

	public GameObject target;

	public Random randomNumber;

	// Use this for initialization
	void Start () {
		randomNumber = new Random ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		FollowPlayer ();
		RotateToPlayer ();
    }

	private void FollowPlayer() {
		// Assigns values to each position vector
		entityPosition = transform.position;
		targetPosition = target.transform.position;
		
		// Determines the direction that the zombie must move towards
		direction = targetPosition - entityPosition;
		direction.z = 0;

		direction.Normalize ();
		
		// Make the zombie move
		Vector3 move = direction * speed + entityPosition;
		transform.position = Vector3.Lerp (entityPosition, move, Time.deltaTime);
	}

	private void RotateToPlayer() {
		// Orients the zombie
		float targetAngle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, targetAngle), turnSpeed * Time.deltaTime);
	}

	private void CheckForDeath() {
		if (zombieHealth <= 0f) {
			Destroy (this.gameObject);
		}
	}

	public void TakeDamage(float amount) {
		zombieHealth -= amount;
        Debug.Log(zombieHealth);

        CheckForDeath();
    }
}
