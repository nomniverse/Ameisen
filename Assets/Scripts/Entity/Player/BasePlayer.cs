using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public class BasePlayer : MonoBehaviour {

    public bool playerEnabled = true;           // Controller enabled
    public float playerHealth = 100f;   // Player health (starts at 100 automatically)

    public float speed = 1.0f;                  // Player movement speed
    private Vector3 entityPosition;             // Position of the player
    private Vector3 playerDirection;            // Direction of the player
    
    public GameObject blockToPlace;             // What block to place
    private Vector3 blockPosition;              // Position to place a block
    public bool allowEdit = true;               // Allows the player to place blocks or shoot

    public GameObject bullet;

    private GameObject weapon;
    public LineRenderer lineRenderer;
    
    public Vector3 rotation;

    private GameObject hpValue;

    public string playerName { get; set; }
    public BaseCharacterClass playerClass { get; set; }

    public int playerLevel { get; set; }
    public int currentPlayerXP { get; set; }
    public int requiredPlayerXP { get; set; }

    public List<BaseStat> playerStats = new List<BaseStat>();
    private static List<BaseItem> playerInventory = new List<BaseItem>();
    private static List<BaseItem> hotbarInventory = new List<BaseItem>();

    private RPGItemDatabase rpgItemDatabase;

    private GameObject inventoryWindow;

    void Start()
    {
        inventoryWindow = GameObject.Find("InventoryWindow");

        playerStats.Add(new BaseStamina());
        playerStats.Add(new BaseEndurance());
        playerStats.Add(new BaseStrength());
        playerStats.Add(new BaseIntelligence());

        weapon = GameObject.FindGameObjectWithTag("Weapon");
        lineRenderer = weapon.GetComponentInChildren<LineRenderer>();
        //inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory>();
        hpValue = GameObject.Find("HPValue");
        hpValue.GetComponent<Text>().text = playerHealth.ToString();
    }

    void Awake()
    {
        rpgItemDatabase = new RPGItemDatabase();
        rpgItemDatabase.LoadXML();
        rpgItemDatabase.ReadItemFromDatabase();

        for (int i = 0; i < 10; i++)
        {
            playerInventory.Add(rpgItemDatabase.inventoryItems[i]);
            Debug.Log(playerInventory[i].itemName + ", " + playerInventory[i].itemDescription + ", " + playerInventory[i].itemID);
        }
    }

    public List<BaseItem> GetPlayerInventory()
    {
        return playerInventory;
    }

    public List<BaseItem> GetHotbarInventory()
    {
        return hotbarInventory;
    }

    public void movePlayer(float xAxis, float yAxis)
    {
        transform.position += xAxis * Vector3.right * Time.deltaTime * speed;
        transform.position += yAxis * Vector3.up * Time.deltaTime * speed;
    }

    public void rotatePlayer()
    {
        entityPosition = Camera.main.WorldToScreenPoint(transform.position);
        playerDirection = Input.mousePosition - entityPosition;
        rotation = new Vector3(0, 0, Mathf.Atan2(playerDirection.y, playerDirection.x));
        GetComponent<Rigidbody2D>().transform.rotation = Quaternion.Euler(rotation * Mathf.Rad2Deg);
    }

    public void addBlock()
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

    public void DestroyBlock()
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

    public void Shoot()
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
            hpValue.GetComponent<Text>().text = playerHealth.ToString();

            if (playerHealth <= 0f)
            {
                playerEnabled = false;
                this.gameObject.AddComponent<GameOver>();
            }
        }
    }
}
