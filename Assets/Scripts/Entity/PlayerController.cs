using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public bool playerEnabled = true;			// Controller enabled
	public float playerHealth = 100f;	// Player health (starts at 100 automatically)

	public float speed = 1.0f;					// Player movement speed
	private Vector3 entityPosition;				// Position of the player
	private Vector3 playerDirection;			// Direction of the player
	
	public float blockCooldown = 10;			// Cooldown on block editing
	private float blockCooldownCount = 0;					// Count of current cooling down

	public GameObject blockToPlace;				// What block to place
	private Vector3 blockPosition;				// Position to place a block
	public GameObject destroyable;				// Used for block deletion
	public bool allowEdit = true;				// Allows the player to place blocks or shoot

	public GameObject bullet;
    public float shootCooldown = 10f;
    private float shootCooldownCount = 0;

    private GameObject weapon;
    private LineRenderer lineRenderer;

    public float blinkCooldown = 5f;
    private float blinkCooldownCount = 0;

	public Vector3 rotation;
	
	//Inventory inventory;

	// Use this for initialization
	void Start () {
        weapon = GameObject.FindGameObjectWithTag("Weapon");
        lineRenderer = weapon.GetComponentInChildren<LineRenderer>();
        //inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (playerEnabled) {
			movePlayer ();
			rotatePlayer ();
			toggleMouseMode ();
			//ToggleInventory ();

            if(blinkCooldownCount >= blinkCooldown)
            {
                lineRenderer.enabled = false;
            }

            if (Input.GetMouseButton(1))
            {
                if (allowEdit)
                {
                    if (blockCooldownCount > blockCooldown)
                    {
                        addBlock();
                        blockCooldownCount = 0;
                    }
                }
                else
                {
                    if (shootCooldownCount > shootCooldown)
                    {
                        Shoot();
                        //Shoot(inventory.getEquippedItem());
                        //Shoot(new Item("test", 1, "projectile", 0, 0, 0, Item.ItemType.Weapon));
                        shootCooldownCount = 0;
                        blinkCooldownCount = 0;
                    }
                }
            }
            blockCooldownCount += 1f;
            shootCooldownCount += 1f;
            blinkCooldownCount += 1f;
        } else {
		}
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
        createBlock(3);
	}

	private void createBlock(int id) {
		//for (int i = 0; i < inventory.Items.Count; i++) {
		//	if (inventory.Items[i].ID == id) {
				
				blockPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				blockPosition.z = 0;
				Instantiate (blockToPlace, blockPosition, Quaternion.identity);
			//	inventory.Items[i].itemValue--;
			//	break;
			//}
		//}
}

    private void Shoot()
    {
        RaycastHit2D hit;
        if (hit = Physics2D.Raycast(weapon.transform.position, weapon.transform.right))
        {
            if (hit.collider)
            {
                lineRenderer.SetPosition(1, new Vector3(hit.distance, 0, 0));
                if (hit.transform.CompareTag("Hostile"))
                {
                    try
                    {
                        hit.transform.GetComponent<ZombieController>().TakeDamage(5);
                    }
                    catch
                    {
                        Debug.Log("WTF");
                    }
                }
            }
            else
            {
                lineRenderer.SetPosition(1, new Vector3(0, 0, 5000));
            }
        }

        lineRenderer.enabled = true;
        
    }
//private void Shoot(Item item) {
//       if (item.itemType == Item.ItemType.Weapon)
//       {
//           switch (item.itemDesc)
//           {
//               case "hitscan":
//                   RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
//                   if (hit.transform != null && hit.transform.CompareTag("Hostile"))
//                   {
//                       try
//                       {
//                           hit.transform.GetComponent<ZombieController>().TakeDamage(5);
//                       }
//                       catch (System.Exception)
//                       {
//                           Debug.Log("wtf");
//                       }
//                   }
//                   break;
//               case "projectile":
//                   Vector3 bulletPosition = new Vector3(GetComponent<Rigidbody2D>().transform.position.x, GetComponent<Rigidbody2D>().transform.position.y, 0);
//                   Instantiate(bullet, bulletPosition, Quaternion.identity);
//                   break;
//               default:
//                   break;
//           }
//       }
//   }

//private void ToggleInventory() {
//	if (Input.GetKeyDown (KeyCode.Tab)) {
//		inventory.shown = !inventory.shown;
//		allowEdit = !allowEdit;
//	}
//}

void OnTriggerEnter2D(Collider2D other)
{
    if (other.gameObject.tag.Equals("Hostile"))
    {
        playerHealth -= 5;

        if (playerHealth <= 0f)
        {
            playerEnabled = false;
            this.gameObject.AddComponent<GameOver>();
        }
    }
}
}
