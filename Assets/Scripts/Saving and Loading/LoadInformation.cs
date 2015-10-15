using UnityEngine;
using System.Collections;

public class LoadInformation {

	public static void LoadAllInformation()
    {
        // Player Information
        GameInformation.PlayerName = PlayerPrefs.GetString("PLAYER_NAME");
        GameInformation.PlayerLevel = PlayerPrefs.GetInt("PLAYER_LEVEL");

        // Stats
        GameInformation.PlayerLevel = PlayerPrefs.GetInt("PLAYER_STAMINA");
        GameInformation.PlayerLevel = PlayerPrefs.GetInt("PLAYER_ENDURANCE");
        GameInformation.PlayerLevel = PlayerPrefs.GetInt("PLAYER_INTELLIGENCE");
        GameInformation.PlayerLevel = PlayerPrefs.GetInt("PLAYER_STRENGTH");

        Debug.Log("Loaded all information");
    }
}
