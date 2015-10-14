using UnityEngine;
using System.Collections;

public class CreateNewPlayer : MonoBehaviour {

    private BasePlayer newPlayer;
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

            newPlayer.playerLevel = 1;
            newPlayer.playerStamina = newPlayer.playerClass.classStamina;
            newPlayer.playerEndurance = newPlayer.playerClass.classEndurance;
            newPlayer.playerIntelligence = newPlayer.playerClass.classIntelligence;
            newPlayer.playerStrength = newPlayer.playerClass.classStrength;
        }
    }
}
