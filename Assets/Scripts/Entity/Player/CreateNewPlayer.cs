using UnityEngine;
using System.Collections;

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
        GameInformation.PlayerStamina = newPlayer.playerStamina;
        GameInformation.PlayerEndurance = newPlayer.playerEndurance;
        GameInformation.PlayerIntelligence = newPlayer.playerIntelligence;
        GameInformation.PlayerStrength = newPlayer.playerStrength;
    }

    private void SetNewPlayerStats()
    {
        newPlayer.playerLevel = 1;
        newPlayer.playerStamina = newPlayer.playerClass.classStamina;
        newPlayer.playerEndurance = newPlayer.playerClass.classEndurance;
        newPlayer.playerIntelligence = newPlayer.playerClass.classIntelligence;
        newPlayer.playerStrength = newPlayer.playerClass.classStrength;
        newPlayer.playerName = playerName;
    }
}
