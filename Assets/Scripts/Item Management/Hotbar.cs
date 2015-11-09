using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Hotbar : MonoBehaviour {

    private List<GameObject> hotbarSlots = new List<GameObject>();
    private List<BaseItem> playerInventory;
    private GameObject itemSlot;
    private int xPos, yPos;

    public int slotsInHotbar;
    public int startingPosX, startingPosY;
    public GameObject itemSlotPrefab;
    public ToggleGroup itemSlotToggleGroup;

    // Use this for initialization
    void Start () {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>().GetHotbarInventory();

        xPos = startingPosX;
        yPos = startingPosY;

        for (int i = 0; i < slotsInHotbar; i++)
        {
            itemSlot = (GameObject)Instantiate(itemSlotPrefab);
            itemSlot.name = "Empty";
            itemSlot.GetComponent<Text>().text = i.ToString();
            itemSlot.GetComponent<Toggle>().group = itemSlotToggleGroup;
            itemSlot.transform.SetParent(this.gameObject.transform);
            itemSlot.GetComponent<RectTransform>().localPosition = new Vector3(xPos, yPos, 0);
            xPos += (int)itemSlot.GetComponent<RectTransform>().rect.width;

            hotbarSlots.Add(itemSlot);
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
