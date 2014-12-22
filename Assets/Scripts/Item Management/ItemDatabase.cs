using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

	public List<Item> items = new List<Item>();
	
	// Use this for initialization
	void Start () {
		items.Add (new Item("A_Armor04", 0, "Swag Armour", 10, 10, 1, Item.ItemType.Chest));
		items.Add (new Item("A_Armor05", 1, "Swag Armour", 10, 10, 1, Item.ItemType.Chest));
		items.Add (new Item("I_Antidote", 2, "Swag Pot", 10, 10, 1, Item.ItemType.Consumerable));
		items.Add (new Item("I_Rock01", 3, "Basic Building Block", 10, 10, 1, Item.ItemType.Building));
	}
}
