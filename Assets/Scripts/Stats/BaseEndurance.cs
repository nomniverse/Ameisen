using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseEndurance : BaseStat {

	public BaseEndurance()
    {
        statName = "Endurance";
        statDescription = "How easily tired are you?";
        statType = StatType.Endurance;
        statBaseValue = 0;
        statModifiedValue = 0;
        statCost = 0;
    }
}
