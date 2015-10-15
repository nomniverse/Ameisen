using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public bool playerEnabled = true;           // Controller enabled
    public float playerHealth = 100f;   // Player health (starts at 100 automatically)

    public float speed = 1.0f;                  // Player movement speed
    private Vector3 entityPosition;             // Position of the player
    private Vector3 playerDirection;            // Direction of the player

    public float buildCooldown = 10f;           // Cooldown on block building
    private float buildCooldownCount = 0f;		// Count of current building cooldown

    public float shootCooldown = 10f;           // Cooldown on shooting
    private float shootCooldownCount = 0f;      // Count of current shooting cooldown

    public float destroyCooldown = 10f;         // Cooldown on block destruction
    private float destroyCooldownCount = 0f;    // Count of current destruction cooldown

    public GameObject blockToPlace;             // What block to place
    private Vector3 blockPosition;              // Position to place a block
    public bool allowEdit = true;               // Allows the player to place blocks or shoot

    public GameObject bullet;

    private GameObject weapon;
    private LineRenderer lineRenderer;

    public float blinkCooldown = 5f;
    private float blinkCooldownCount = 0;

    public Vector3 rotation;

    //Inventory inventory;

    // Use this for initialization
    void Start()
    {
        weapon = GameObject.FindGameObjectWithTag("Weapon");
        lineRenderer = weapon.GetComponentInChildren<LineRenderer>();
        //inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerEnabled)
        {
            movePlayer();
            rotatePlayer();
            toggleMouseMode();
            //ToggleInventory ();

            if (blinkCooldownCount >= blinkCooldown)
            {
                lineRenderer.enabled = false;
            }

            if (Input.GetMouseButton(1))
            {
                if (allowEdit)
                {
                    if (buildCooldownCount > buildCooldown)
                    {
                        addBlock();
                        buildCooldownCount = 0;
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

            if (Input.GetMouseButton(0))
            {
                if (allowEdit)
                {
                    if (destroyCooldownCount > destroyCooldown)
                    {
                        DestroyBlock();
                        destroyCooldownCount = 0;
                    }
                }
                else
                {
                    // TODO Left Mouse Shoot Action
                }
            }

            destroyCooldownCount += 1f;
            buildCooldownCount += 1f;
            shootCooldownCount += 1f;
            blinkCooldownCount += 1f;
        }
        else
        {
        }
    }

    private void movePlayer()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
    }

    private void rotatePlayer()
    {
        entityPosition = Camera.main.WorldToScreenPoint(transform.position);
        playerDirection = Input.mousePosition - entityPosition;
        rotation = new Vector3(0, 0, Mathf.Atan2(playerDirection.y, playerDirection.x));
        GetComponent<Rigidbody2D>().transform.rotation = Quaternion.Euler(rotation * Mathf.Rad2Deg);
    }

    private void toggleMouseMode()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            allowEdit = !allowEdit;
        }
    }

    private void addBlock()
    {
        createBlock(3);
    }

    private void createBlock(int id)
    {
        //for (int i = 0; i < inventory.Items.Count; i++) {
        //	if (inventory.Items[i].ID == id) {

        blockPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        blockPosition.z = 0;
        Instantiate(blockToPlace, blockPosition, Quaternion.identity);
        //	inventory.Items[i].itemValue--;
        //	break;
        //}
        //}
    }

    void DestroyBlock()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit)
        {
            if (hit.collider.gameObject.tag == "Block")
            {
                Debug.Log(hit.collider.tag);
                Destroy(hit.collider.gameObject);
                //inventory.AddItem (3);
            }
        }
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
