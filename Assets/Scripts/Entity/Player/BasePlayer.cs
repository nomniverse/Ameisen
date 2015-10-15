using UnityEngine;
using System.Collections;

public class BasePlayer {

    public string playerName { get; set; }
    public BaseCharacterClass playerClass { get; set; }

    public int playerLevel { get; set; }
    public int currentPlayerXP { get; set; }
    public int requiredPlayerXP { get; set; }

    public int playerStamina { get; set; }
    public int playerEndurance { get; set; }
    public int playerIntelligence { get; set; }
    public int playerStrength { get; set; }
}
