using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public List<GameObject> Slots = new List<GameObject>();
	public List<Item> Items = new List<Item>();
	public GameObject slots;
	ItemDatabase database;
	int x = -225;
	int y = 200;
	
	public GameObject tooltip;
	public GameObject draggedItemIcon;
	public Item itemDragged;
	public int previousDrag;
	public bool draggingItem;
	
	public int intervalBetweenSlots = 65;
	public bool shown = false;

	// Use this for initialization
	void Start () {
		gameObject.transform.parent.GetComponent<Canvas>().enabled = false;
		int SlotAmount = 0;
		database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
	
		for (int i = 1; i < 8; i++) {
			for (int j = 1; j < 8 + 1; j++) {
				GameObject slot = (GameObject) Instantiate (slots);
				slot.GetComponent<SlotScript>().slotNumber = SlotAmount;
				Slots.Add(slot);
				Items.Add (new Item());
				slot.transform.SetParent (this.gameObject.transform, false);
				slot.name = "Slot" + i + "." + j;
				slot.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0);
				x += intervalBetweenSlots;
				
				if (j == 8) {
					x = -225;
					y -= intervalBetweenSlots;
				}
				SlotAmount++;
			}
		}
		AddItem (0);
		AddItem (1);
		AddItem (2);
		AddItem (2);
		for (int i = 0; i < 64; i++) {
			AddItem (3);
		}
		
	}
	
	void Update() {
		if (shown) {
			gameObject.transform.parent.GetComponent<Canvas>().enabled = true;
		} else {
			gameObject.transform.parent.GetComponent<Canvas>().enabled =  false;
		}
		if (draggingItem) {
			Vector3 mousePosition = (Input.mousePosition - GameObject.FindGameObjectWithTag("Canvas").GetComponent<RectTransform>().localPosition);
			draggedItemIcon.GetComponent<RectTransform>().localPosition = new Vector3(mousePosition.x + 25, mousePosition.y - 25, mousePosition.z);
		}
	}
	
	public void AddItem(int id) {
		for (int i = 0; i < database.items.Count; i++) {
			if (database.items[i].itemID == id) {
				Item item = database.items[i];
				if (database.items[i].itemType == Item.ItemType.Consumerable || database.items[i].itemType == Item.ItemType.Building) {
					checkIfItemExists(id, item);
					break;
				} else {
					AddItemAtEmptySlot(item);
					break;
				}
			}
		}
	}
	
	void AddItemAtEmptySlot(Item item) {
		for (int i = 0; i < Items.Count; i++) {
			if (Items[i].itemName == null) {
				Items[i] = item;
				break;
			}
		}
	}
	
	public void checkIfItemExists(int itemID, Item item) {
		for (int i = 0; i < Items.Count; i++) {
			if (Items[i].itemID == itemID) {
				Items[i].itemValue = Items[i].itemValue + 1;
				break;
			} else if (i == (Items.Count - 1)){
				AddItemAtEmptySlot (item);
				break;
			}
		}
	}
	
	public void ShowTooltip(Vector3 tooltipPosition, Item item) {
		tooltip.SetActive (true);
		tooltip.GetComponent<RectTransform>().localPosition = tooltipPosition;
		tooltip.transform.GetChild (0).GetComponent<Text>().text = item.itemName;
		tooltip.transform.GetChild (1).GetComponent<Text>().text = "Stats Go Here";
		tooltip.transform.GetChild (2).GetComponent<Text>().text = item.itemDesc;
	}
	
	public void CloseTooltip() {
		tooltip.SetActive (false);
	}
	
	public void ShowDraggedItem(Item item, int slotNumber) {
		draggingItem = true;
		itemDragged = item;
		previousDrag = slotNumber;
		CloseTooltip ();
		draggedItemIcon.SetActive (true);
		draggedItemIcon.GetComponent<Image>().sprite = item.itemIcon;
	}
	
	public void CloseDraggedItem() {
		draggingItem = false;
		draggedItemIcon.SetActive (false);
	}
}
