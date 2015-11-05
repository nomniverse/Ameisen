using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public class BasePlayer : MonoBehaviour {

    public string playerName { get; set; }
    public BaseCharacterClass playerClass { get; set; }

    public int playerLevel { get; set; }
    public int currentPlayerXP { get; set; }
    public int requiredPlayerXP { get; set; }

    public List<BaseStat> playerStats = new List<BaseStat>();
    private List<BaseItem> playerInventory = new List<BaseItem>();

    void Start()
    {
        playerStats.Add(new BaseStamina());
        playerStats.Add(new BaseEndurance());
        playerStats.Add(new BaseStrength());
        playerStats.Add(new BaseIntelligence());
    }

    void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            playerInventory.Add(RPGItemDatabase.inventoryItems[i]);
            Debug.Log(playerInventory[i].itemName + ", " + playerInventory[i].itemDescription + ", " + playerInventory[i].itemID);
        }
    }

    public List<BaseItem> GetPlayerInventory()
    {
        return playerInventory;
    }
}
