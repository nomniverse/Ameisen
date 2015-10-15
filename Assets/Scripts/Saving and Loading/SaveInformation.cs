using UnityEngine;
using System.Collections;

public class SaveInformation
{

    public static void SaveAllInformation()
    {
        // Player Information
        PlayerPrefs.SetString("PLAYER_NAME", GameInformation.PlayerName);
        PlayerPrefs.SetInt("PLAYER_LEVEL", GameInformation.PlayerLevel);

        // Stats
        PlayerPrefs.SetInt("PLAYER_STAMINA", GameInformation.PlayerStamina);
        PlayerPrefs.SetInt("PLAYER_ENDURANCE", GameInformation.PlayerEndurance);
        PlayerPrefs.SetInt("PLAYER_INTELLIGENCE", GameInformation.PlayerIntelligence);
        PlayerPrefs.SetInt("PLAYER_STRENGTH", GameInformation.PlayerStrength);

        Debug.Log("Saved all information");
    }
}
