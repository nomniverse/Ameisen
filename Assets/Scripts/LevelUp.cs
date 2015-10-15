using UnityEngine;
using System.Collections;

public class LevelUp {

    public int maxPlayerLevel = 50;

	public void LevelUpCharacter()
    {
        if (GameInformation.CurrentXP > GameInformation.RequiredXP)
        {
            GameInformation.CurrentXP -= GameInformation.RequiredXP;
        }
        else
        {
            GameInformation.CurrentXP = 0;
        }

        if (GameInformation.PlayerLevel < maxPlayerLevel)
        {
            GameInformation.PlayerLevel += 1;
        } else
        {
            GameInformation.PlayerLevel = maxPlayerLevel;
        }

        DetermineNextRequiredXP();
    }

    private void DetermineNextRequiredXP()
    {
        float levelMultiplier = 1000f;
        float startingXPRequired = 250f;

        GameInformation.RequiredXP = (int)((GameInformation.PlayerLevel * levelMultiplier) + startingXPRequired);
    }
}
