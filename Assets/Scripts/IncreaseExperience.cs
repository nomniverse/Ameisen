using UnityEngine;
using System.Collections;

public class IncreaseExperience {

    private static int xpToGive;
    private static int simpleXPMultiplier = 100;

    private static LevelUp levelUp = new LevelUp();

    public static void AddXP()
    {
        xpToGive = GameInformation.PlayerLevel * simpleXPMultiplier;
        GameInformation.CurrentXP += xpToGive;

        CheckForLevelUp();
    }

    private static void CheckForLevelUp()
    {
        if (GameInformation.CurrentXP >= GameInformation.RequiredXP)
        {
            levelUp.LevelUpCharacter();
        }
    }
}
