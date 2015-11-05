using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryWindow : MonoBehaviour {

    public int startingPosX, startingPosY;
    public int slotCountPerPage, slotCountLength;

    public GameObject itemSlotPrefab;
    public ToggleGroup itemSlotToggleGroup;

    private int xPos, yPos;
    private GameObject itemSlot;
    private int itemSlotCount;

    private List<GameObject> inventorySlots;
    private List<BaseItem> playerInventory;

	// Use this for initialization
	void Start () {
        CreateInventorySlotsInWindow();
        AddItemsFromInventory();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void CreateInventorySlotsInWindow()
    {
        inventorySlots = new List<GameObject>();

        xPos = startingPosX;
        yPos = startingPosY;

        for (int i = 0; i < slotCountPerPage; i++)
        {
            itemSlot = (GameObject)Instantiate(itemSlotPrefab);
            itemSlot.name = "Empty";
            itemSlot.GetComponent<Toggle>().group = itemSlotToggleGroup;
            itemSlot.transform.SetParent(this.gameObject.transform);
            itemSlot.GetComponent<RectTransform>().localPosition = new Vector3(xPos, yPos, 0);
            xPos += (int)itemSlot.GetComponent<RectTransform>().rect.width;
            itemSlotCount++;

            if (itemSlotCount % slotCountLength == 0)
            {
                itemSlotCount = 0;
                yPos -= (int)itemSlot.GetComponent<RectTransform>().rect.width;
                xPos = startingPosX;
            }

            inventorySlots.Add(itemSlot);
        }
    }

    private void AddItemsFromInventory()
    {
        BasePlayer basePlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        playerInventory = basePlayerScript.GetPlayerInventory();

        Debug.Log(playerInventory.Count);

        for (int i = 0; i < playerInventory.Count; i++)
        {
            if (inventorySlots[i].name.Equals("Empty"))
            {
                //inventorySlots[i].name = playerInventory[i].itemName;
                inventorySlots[i].name = i.ToString();
                inventorySlots[i].transform.GetChild(0).gameObject.SetActive(true);
                inventorySlots[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = GetItemIcon(playerInventory[i]);
            }
        }
    }

    private Sprite GetItemIcon(BaseItem item)
    {
        Sprite icon = new Sprite();

        switch(item.itemType)
        {
            case BaseItem.ItemType.Building:
                icon = Resources.Load<Sprite>("Graphics/Icons/Building");
                break;
            case BaseItem.ItemType.Chest:
                icon = Resources.Load<Sprite>("Graphics/Icons/Chest");
                break;
            case BaseItem.ItemType.Consumerable:
                icon = Resources.Load<Sprite>("Graphics/Icons/Consumerable");
                break;
            case BaseItem.ItemType.Equipment:
                icon = Resources.Load<Sprite>("Graphics/Icons/Equipment");
                break;
            case BaseItem.ItemType.Scroll:
                icon = Resources.Load<Sprite>("Graphics/Icons/Scroll");
                break;
            case BaseItem.ItemType.Weapon:
                icon = Resources.Load<Sprite>("Graphics/Icons/Weapon");
                break;
            default:
                break;
        }

        return icon;
    }
}
