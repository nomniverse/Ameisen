using UnityEngine;
using System.Collections;

public class BaseItem {

	private string name, desc;
	private int ID;
	private ItemType type;

	public enum ItemType {
		Weapon,
		Consumerable,
		Equipment,
        Chest,
        Scroll,
		Building
	}
    
    public string itemName
    {
        get { return name; }
        set { name = value; }
    }

    public string itemDescription
    {
        get { return desc; }
        set { desc = value; }
    }

    public int itemID
    {
        get { return ID; }
        set { ID = value; }
    }

    public ItemType itemType
    {
        get { return type; }
        set { type = value; }
    }
}
