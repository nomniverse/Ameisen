using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseItem {

	public enum ItemType {
		Weapon,
		Consumerable,
		Equipment,
        Chest,
        Scroll,
		Building
	}
    
    public string itemName { get; set; }

    public string itemDescription { get; set; }

    public int itemID { get; set; }

    public ItemType itemType { get; set; }
}
