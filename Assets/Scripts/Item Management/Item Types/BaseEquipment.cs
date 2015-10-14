using UnityEngine;
using System.Collections;

public class BaseEquipment : BaseStatItem {

	public enum EquipmentType
    {
        Head,
        Chest,
        Legs,
        Feet
    }

    private EquipmentType eType;
    private int effectID;

    public EquipmentType equipmentType
    {
        get { return eType; }
        set { eType = value; }
    }

    public int spellEffectID
    {
        get { return effectID; }
        set { effectID = value; }
    }
}
