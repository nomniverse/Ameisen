using UnityEngine;
using System.Collections;

public class BasePlayer {

    private string name;
    private int level, stamina, endurance, intelligence, strength;
    private BaseCharacterClass pClass;

    public string playerName
    {
        get { return name; }
        set { name = value; }
    }

    public BaseCharacterClass playerClass
    {
        get { return pClass; }
        set { pClass = value; }
    }

    public int playerLevel
    {
        get { return level; }
        set { level = value; }
    }

    public int playerStamina
    {
        get { return stamina; }
        set { stamina = value; }
    }

    public int playerEndurance
    {
        get { return endurance; }
        set { endurance = value; }
    }

    public int playerIntelligence
    {
        get { return intelligence; }
        set { intelligence = value; }
    }

    public int playerStrength
    {
        get { return strength; }
        set { strength = value; }
    }
}
