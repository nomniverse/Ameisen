using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BaseBuildingItem : BaseItem {

	public enum BuildingItemType
    {
        Block,
        Furniture
    }

    public BuildingItemType buildingItemType { get; set; }
}
