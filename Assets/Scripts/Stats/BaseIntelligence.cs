using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseIntelligence : BaseStat {

	public BaseIntelligence()
    {
        statName = "Intelligence";
        statDescription = "How smart are you?";
        statType = StatType.Intelligence;
        statBaseValue = 0;
        statModifiedValue = 0;
        statCost = 0;
    }
}
