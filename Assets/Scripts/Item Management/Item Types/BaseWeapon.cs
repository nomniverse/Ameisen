using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseWeapon : BaseStatItem {

	public enum WeaponType
    {
        Melee,
        Ranged
    }

    private WeaponType wType;
    private int effectID;

    public WeaponType weaponType
    {
        get { return wType; }
        set { wType = value; }
    }

    public int spellEffectID
    {
        get { return effectID; }
        set { effectID = value; }
    }
}
