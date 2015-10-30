using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseStamina : BaseStat {

	public BaseStamina()
    {
        statName = "Stamina";
        statDescription = "How much health do you have?";
        statType = StatType.Stamina;
        statBaseValue = 0;
        statModifiedValue = 0;
        statCost = 0;
    }
}
