using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class CreateNewPlayer : MonoBehaviour {

    private BasePlayer newPlayer;
    private string playerName = "Enter Player Name";
    private bool isMageClass, isWarriorClass;

	// Use this for initialization
	void Start () {
        newPlayer = new BasePlayer();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        playerName = GUILayout.TextArea(playerName);

        isMageClass = GUILayout.Toggle(isMageClass, "Mage Class");
        isWarriorClass = GUILayout.Toggle(isWarriorClass, "Warrior Class");

        if (GUILayout.Button("Create Player"))
        {
            if (isMageClass)
            {
                newPlayer.playerClass = new BaseMageClass();
            }
            else if (isWarriorClass)
            {
                newPlayer.playerClass = new BaseWarriorClass();
            }
            else { }

            SetNewPlayerStats();                        // Sets the player stats in the base player class
            StoreNewPlayerInfo();                       // Stores information in static Game Information class
            SaveInformation.SaveAllInformation();       // Saves everything
        }

        if (GUILayout.Button("Load Game"))
        {
            Application.LoadLevel("test");
        }
    }

    private void StoreNewPlayerInfo()
    {
        // Player Information
        GameInformation.PlayerName = newPlayer.playerName;
        GameInformation.PlayerLevel = newPlayer.playerLevel;

        // Stats
        GameInformation.PlayerStamina = newPlayer.playerStats[Constants.STAMINA_INDEX].statModifiedValue;
        GameInformation.PlayerEndurance = newPlayer.playerStats[Constants.ENDURANCE_INDEX].statModifiedValue;
        GameInformation.PlayerIntelligence = newPlayer.playerStats[Constants.INTELLIGENCE_INDEX].statModifiedValue;
        GameInformation.PlayerStrength = newPlayer.playerStats[Constants.STRENGTH_INDEX].statModifiedValue;
    }

    private void SetNewPlayerStats()
    {
        newPlayer.playerLevel = 1;
        newPlayer.playerStats[Constants.STAMINA_INDEX].statModifiedValue = newPlayer.playerClass.classStamina;
        newPlayer.playerStats[Constants.ENDURANCE_INDEX].statModifiedValue = newPlayer.playerClass.classEndurance;
        newPlayer.playerStats[Constants.INTELLIGENCE_INDEX].statModifiedValue = newPlayer.playerClass.classIntelligence;
        newPlayer.playerStats[Constants.STRENGTH_INDEX].statModifiedValue = newPlayer.playerClass.classStrength;
        newPlayer.playerName = playerName;
    }
}
