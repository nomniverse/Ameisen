using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseEquipment : BaseItem {

	public enum EquipmentType
    {
        Head,
        Chest,
        Legs,
        Feet
    }

    public EquipmentType equipmentType { get; set; }

    public int spellEffectID { get; set; }
}
