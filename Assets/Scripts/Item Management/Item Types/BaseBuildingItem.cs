using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseBuildingItem : BaseItem {

	public enum BuildingItemType
    {
        Block,
        Furniture
    }

    public BuildingItemType buildingItemType { get; set; }
}
