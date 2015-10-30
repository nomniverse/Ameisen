using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseStat {

    public string statName { get; set; }
    public string statDescription { get; set; }

    public float statBaseValue { get; set; }
    public float statModifiedValue { get; set; }

    public StatType statType { get; set; }

    public enum StatType
    {
        Stamina,
        Endurance,
        Strength,
        Intelligence
    }
}
