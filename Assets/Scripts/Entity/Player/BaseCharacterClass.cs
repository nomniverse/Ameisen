using UnityEngine;
using System.Collections;

public class BaseCharacterClass {

    private string name, desc;
    private int stamina, endurance, strength, intelligence;

    public string className
    {
        get { return name; }
        set { name = value; }
    }

    public string classDescription
    {
        get { return desc; }
        set { desc = value; }
    }

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
