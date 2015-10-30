using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseStrength : BaseStat {

	public BaseStrength()
    {
        statName = "Strength";
        statDescription = "How strong are you?";
        statType = StatType.Strength;
        statBaseValue = 0;
        statModifiedValue = 0;
        statCost = 0;
    }
}
