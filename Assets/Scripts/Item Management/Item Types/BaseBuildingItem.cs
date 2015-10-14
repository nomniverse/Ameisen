using UnityEngine;
using System.Collections;

public class BaseBuildingItem : BaseItem {

	public enum BuildingItemType
    {
        Block,
        Furniture
    }

    private BuildingItemType bType;

    public BuildingItemType buildingItemType
    {
        get { return bType; }
        set { bType = value; }
    }
}
