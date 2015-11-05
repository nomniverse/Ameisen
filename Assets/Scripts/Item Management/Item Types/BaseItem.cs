using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseItem {

    public string[] names = new string[4] { "Poor", "Common", "Special", "Godly" };

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
        itemName = "Item " + Random.Range(0, 101);
        itemDescription = "Randomly generated item";
    }

    public BaseItem(Dictionary<string,string> dictionary)
    {
        itemName = dictionary["ItemName"];
        itemDescription = dictionary["ItemDescription"];
        itemID = int.Parse(dictionary["ItemID"]);
        itemType = (ItemType) System.Enum.Parse(typeof(ItemType), dictionary["ItemType"]);

        itemStats[Constants.STAMINA_INDEX].statBaseValue = int.Parse(dictionary["StaminaModifier"]);
        itemStats[Constants.ENDURANCE_INDEX].statBaseValue = int.Parse(dictionary["EnduranceModifier"]);
        itemStats[Constants.STRENGTH_INDEX].statBaseValue = int.Parse(dictionary["StrengthModifier"]);
        itemStats[Constants.INTELLIGENCE_INDEX].statBaseValue = int.Parse(dictionary["IntelligenceModifier"]);
    }

    public string itemName { get; set; }

    public string itemDescription { get; set; }

    public int itemID { get; set; }

    public BaseStat[] itemStats = { new BaseStamina(), new BaseEndurance(), new BaseStrength(), new BaseEndurance() };

    public ItemType itemType { get; set; }
}
