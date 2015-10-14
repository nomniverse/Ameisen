using UnityEngine;
using System.Collections;

public class BaseWarriorClass : BaseCharacterClass
{

    public BaseWarriorClass()
    {
        className = "Warrior";
        classDescription = "You like bashing things in.";
        classStamina = 15;
        classEndurance = 12;
        classStrength = 14;
        classIntelligence = 10;
    }
}
