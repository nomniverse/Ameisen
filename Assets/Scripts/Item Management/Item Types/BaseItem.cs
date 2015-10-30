using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BaseItem {

    public enum ItemType
    {
        Weapon,
        Consumerable,
        Equipment,
        Chest,
        Scroll,
        Building
    }

    public BaseItem()
    {

    }

    public BaseItem(Dictionary<string,string> dictionary)
    {
        itemName = dictionary["ItemName"];
        itemDescription = dictionary["ItemDescription"];
        itemID = int.Parse(dictionary["ItemID"]);
        itemType = (ItemType) System.Enum.Parse(typeof(ItemType), dictionary["ItemType"]);

        staminaModifier = int.Parse(dictionary["ItemStamina"]);
    }

    public string itemName { get; set; }

    public string itemDescription { get; set; }

    public int itemID { get; set; }

    public ItemType itemType { get; set; }

    public int staminaModifier { get; set; }

    public int enduranceModifier { get; set; }

    public int strengthModifier { get; set; }

    public int intelligenceModifier { get; set; }
}
