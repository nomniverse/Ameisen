using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler {

	public Item item;
	Image itemImage;
	public int slotNumber;
	Inventory inventory;
	Text amount;

	// Use this for initialization
	void Start () {
		amount = gameObject.transform.GetChild (1).GetComponent<Text>();
		inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
		itemImage = gameObject.transform.GetChild (0).GetComponent <Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (inventory.Items[slotNumber].itemName != null) {
			amount.enabled = false;
			item = inventory.Items[slotNumber];
			itemImage.enabled = true;
			itemImage.sprite = inventory.Items[slotNumber].itemIcon;
			if (inventory.Items[slotNumber].itemType == Item.ItemType.Consumerable || inventory.Items[slotNumber].itemType == Item.ItemType.Building) {
				amount.enabled = true;
				amount.text = inventory.Items[slotNumber].itemValue.ToString ();
				CheckForAmount ();
			}
		} else {
			itemImage.enabled = false;
		}
	}
	
	public void CheckForAmount() {
		if (inventory.Items[slotNumber].itemValue == 0) {
			inventory.Items[slotNumber] = new Item();
			amount.enabled = false;
			inventory.CloseTooltip ();
		}
	}
	
	public void OnPointerDown(PointerEventData data) {
		if (data.button == PointerEventData.InputButton.Right) {
			if (inventory.Items[slotNumber].itemType == Item.ItemType.Consumerable) {
				inventory.Items[slotNumber].itemValue--;
//				CheckForAmount ();
			}
		}
		if (inventory.draggingItem) {
			if (inventory.Items[slotNumber].itemName == null) {
				inventory.Items[slotNumber] = inventory.itemDragged;
			} else {
				inventory.Items[inventory.previousDrag] = inventory.Items[slotNumber];
				inventory.Items[slotNumber] = inventory.itemDragged;
			}
			inventory.CloseDraggedItem ();
		}
	}
	
	public void OnPointerEnter(PointerEventData data) {
		if (inventory.Items[slotNumber].itemName != null && !inventory.draggingItem) {
			inventory.ShowTooltip(inventory.Slots[slotNumber].GetComponent<RectTransform>().localPosition, inventory.Items[slotNumber]);
		}
	}
	
	public void OnPointerExit(PointerEventData data) {
		if (inventory.Items[slotNumber].itemName != null) {
			inventory.CloseTooltip();
		}
	}
	
	public void OnDrag(PointerEventData data) {
		if (inventory.Items[slotNumber].itemName != null) {
			inventory.ShowDraggedItem (inventory.Items[slotNumber], slotNumber);
			inventory.Items[slotNumber] = new Item();
			amount.enabled = false;
		}
	}
}
