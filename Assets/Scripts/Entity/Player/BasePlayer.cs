using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public class BasePlayer {

    public string playerName { get; set; }
    public BaseCharacterClass playerClass { get; set; }

    public int playerLevel { get; set; }
    public int currentPlayerXP { get; set; }
    public int requiredPlayerXP { get; set; }

    public List<BaseStat> playerStats = new List<BaseStat>();

    public BasePlayer()
    {
        playerStats.Add(new BaseStamina());
        playerStats.Add(new BaseEndurance());
        playerStats.Add(new BaseStrength());
        playerStats.Add(new BaseIntelligence());
    }
}
