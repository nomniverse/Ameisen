using UnityEngine;
using System.Collections;

public class DisplayCreatePlayerFunctions {

    private int classSelection;
    private string[] classSelectionNames = new string[] { "Mage", "Warrior" };

	public void DisplayClassSelection()
    {
        classSelection = GUI.SelectionGrid(new Rect(50, 50, 250, 250), classSelection, classSelectionNames, 2);
        GUI.Label(new Rect(400, 50, 300, 300), FindClassDescription(classSelection));
        GUI.Label(new Rect(400, 100, 300, 300), FindClassStatValues(classSelection));
    }

    public void DisplayStatAllocation()
    {

    }

    public void DisplayFinalSetup()
    {

    }

    public void DisplayMainItems()
    {
        GUI.Label(new Rect((Screen.width / 2), 20, 100, 100), "Create Player");
    }

    private string FindClassDescription(int classSelection)
    {
        BaseCharacterClass tempClass = new BaseCharacterClass();

        switch (classSelection)
        {
            case 0:
                tempClass = new BaseMageClass();
                break;
            case 1:
                tempClass = new BaseWarriorClass();
                break;
            default:
                break;
            
        }

        return tempClass.classDescription;
    }

    private string FindClassStatValues(int classSelection)
    {
        BaseCharacterClass tempClass = new BaseCharacterClass();

        switch (classSelection)
        {
            case 0:
                tempClass = new BaseMageClass();
                break;
            case 1:
                tempClass = new BaseWarriorClass();
                break;
            default:
                break;

        }

        return "Stamina: " + tempClass.classStamina + "\n" +
                "Endurance: " + tempClass.classEndurance + "\n" +
                "Intelligence: " + tempClass.classIntelligence + "\n" +
                "Strength: " + tempClass.classStrength;
    }
}
