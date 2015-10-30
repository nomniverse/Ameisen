using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseStat {

    public string statName { get; set; }
    public string statDescription { get; set; }

    public int statBaseValue { get; set; }
    public int statModifiedValue { get; set; }

    public StatType statType { get; set; }

    public int statCost { get; set; }

    public enum StatType
    {
        Stamina,
        Endurance,
        Strength,
        Intelligence
    }
}
