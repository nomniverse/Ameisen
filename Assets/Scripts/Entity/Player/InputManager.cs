using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    private GameObject inventoryWindow;
    private BasePlayer playerScript;

    public float buildCooldown = 10f;           // Cooldown on block building
    private float buildCooldownCount = 0f;		// Count of current building cooldown

    public float shootCooldown = 10f;           // Cooldown on shooting
    private float shootCooldownCount = 0f;      // Count of current shooting cooldown

    public float destroyCooldown = 10f;         // Cooldown on block destruction
    private float destroyCooldownCount = 0f;    // Count of current destruction cooldown

    public float blinkCooldown = 5f;
    private float blinkCooldownCount = 0;

    // Use this for initialization
    void Start () {
        inventoryWindow = GameObject.Find("InventoryWindow");
        playerScript = this.transform.parent.GetComponent<BasePlayer>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (playerScript.playerEnabled)
        {
            playerScript.rotatePlayer();

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                playerScript.allowEdit = !playerScript.allowEdit;
            }

            playerScript.movePlayer(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (Input.GetKeyDown(KeyCode.I))
            {
                Debug.Log("Inventory pressed");
                inventoryWindow.SetActive(!inventoryWindow.activeSelf);
            }

            if (blinkCooldownCount >= blinkCooldown)
            {
                playerScript.lineRenderer.enabled = false;
            }

            if (Input.GetMouseButton(1))
            {
                if (playerScript.allowEdit)
                {
                    if (buildCooldownCount > buildCooldown)
                    {
                        playerScript.addBlock();
                        buildCooldownCount = 0;
                    }
                }
                else
                {
                    if (shootCooldownCount > shootCooldown)
                    {
                        playerScript.Shoot();
                        //Shoot(inventory.getEquippedItem());
                        //Shoot(new Item("test", 1, "projectile", 0, 0, 0, Item.ItemType.Weapon));
                        shootCooldownCount = 0;
                        blinkCooldownCount = 0;
                    }
                }
            }

            if (Input.GetMouseButton(0))
            {
                if (playerScript.allowEdit)
                {
                    if (destroyCooldownCount > destroyCooldown)
                    {
                        playerScript.DestroyBlock();
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
}
