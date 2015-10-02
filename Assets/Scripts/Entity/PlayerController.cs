using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public bool playerEnabled = true;			// Controller enabled
	public static float playerHealth = 100f;	// Player health (starts at 100 automatically)

	public float speed = 1.0f;					// Player movement speed
	private Vector3 entityPosition;				// Position of the player
	private Vector3 playerDirection;			// Direction of the player
	
	public float cooldown = 10;					// Cooldown on block editing
	private float count = 0;					// Count of current cooling down

	public GameObject blockToPlace;				// What block to place
	private Vector3 blockPosition;				// Position to place a block
	public GameObject destroyable;				// Used for block deletion
	public bool allowEdit = true;				// Allows the player to place blocks or shoot

	public GameObject bullet;

	public Vector3 rotation;
	
	Inventory inventory;

	// Use this for initialization
	void Start () {
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerEnabled) {
			movePlayer ();
			rotatePlayer ();
			toggleMouseMode ();
			ToggleInventory ();
			if (allowEdit) {
					addBlock ();
			} else {
					if (Input.GetMouseButton (1)) {
							Shoot ();
					}
			}
		} else {
		}
		CheckForDeath ();
	}

	private void movePlayer() {
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			GetComponent<Rigidbody2D>().transform.position += Vector3.up * Time.deltaTime * speed;
		}
		
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			GetComponent<Rigidbody2D>().transform.position += Vector3.left * Time.deltaTime * speed;
		}
		
		if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
			GetComponent<Rigidbody2D>().transform.position += Vector3.down * Time.deltaTime * speed;
		}
		
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			GetComponent<Rigidbody2D>().transform.position += Vector3.right * Time.deltaTime * speed;
		}
	}

	private void rotatePlayer() {
		entityPosition = Camera.main.WorldToScreenPoint (transform.position);
		playerDirection = Input.mousePosition - entityPosition;
		rotation = new Vector3 (0, 0, Mathf.Atan2 (playerDirection.y, playerDirection.x));
		GetComponent<Rigidbody2D>().transform.rotation = Quaternion.Euler (rotation * Mathf.Rad2Deg);
	}

	private void toggleMouseMode() {
		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			allowEdit = !allowEdit;
		}
	}

	private void addBlock() {
		if (count > cooldown) {
			if (Input.GetMouseButton(1) && allowEdit) {
				createBlock(3);
				count = 0;
			}
		} else {
			count += 1f;
		}
	}

	private void createBlock(int id) {
		for (int i = 0; i < inventory.Items.Count; i++) {
			if (inventory.Items[i].itemID == id) {
				
				blockPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				blockPosition.z = 0;
				Instantiate (blockToPlace, blockPosition, Quaternion.identity);
				inventory.Items[i].itemValue--;
				break;
			}
		}
	}

	private void Shoot() {
		Vector3 bulletPosition = new Vector3 (GetComponent<Rigidbody2D>().transform.position.x, GetComponent<Rigidbody2D>().transform.position.y, 0);
		Instantiate (bullet, bulletPosition, Quaternion.identity);
	}

	private void CheckForDeath() {
		if (playerHealth <= 0f) {
			playerEnabled = false;
			Destroy(gameObject);
		}
	}
	
	private void ToggleInventory() {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			inventory.shown = !inventory.shown;
			allowEdit = !allowEdit;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag.Equals ("Hostile")) {
			playerHealth -= 10;
		}
	}
}
