using UnityEngine;
using System.Collections;

public class BaseStatItem : BaseItem {

    private int stamina, endurance, strength, intelligence;

    public int classStamina
    {
        get { return stamina; }
        set { stamina = value; }
    }

    public int classEndurance
    {
        get { return endurance; }
        set { endurance = value; }
    }

    public int classStrength
    {
        get { return strength; }
        set { strength = value; }
    }

    public int classIntelligence
    {
        get { return intelligence; }
        set { intelligence = value; }
    }
}
