using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System;

public class SelectedItem : MonoBehaviour, IDragHandler, IPointerDownHandler {

    private Text selectedItemText;
    private List<BaseItem> playerInventory;
    private InventoryWindow inventoryWindow;

    // Use this for initialization
    void Start () {
        inventoryWindow = GameObject.Find("InventoryWindow").GetComponent<InventoryWindow>();
        selectedItemText = GameObject.Find("SelectedItemText").GetComponent<Text>();
        BasePlayer basePlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        playerInventory = basePlayerScript.GetPlayerInventory();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowSelectedItemText()
    {
        if (this.gameObject.GetComponent<Toggle>().isOn) {
            if (this.gameObject.name == "Empty")
            {
                selectedItemText.text = "This slot is empty.";
            } else
            {
                selectedItemText.text = playerInventory[System.Int32.Parse(this.gameObject.name)].itemName + " " + playerInventory[System.Int32.Parse(this.gameObject.name)].itemDescription;
            }
        } 
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!inventoryWindow.beingDragged && this.name != "Empty")
        {
            inventoryWindow.ShowDraggedItem(this.transform.name);
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.name = "Empty";
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (inventoryWindow.beingDragged)
        {
            if (this.name != "Empty")
            {
                inventoryWindow.SwapItem(this.gameObject);
            }
            else
            {
                this.transform.name = inventoryWindow.AddItemToSlot(this.gameObject);
                this.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}
