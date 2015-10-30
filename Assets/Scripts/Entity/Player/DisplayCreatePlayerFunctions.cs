using UnityEngine;
using System.Collections;

public class DisplayCreatePlayerFunctions {

    private int classSelection;
    private string[] classSelectionNames = new string[] { "Mage", "Warrior" };

    private string[] statNames = new string[4] { "Stamina", "Endurance", "Intelligence", "Strength" };
    private string[] statDescription = new string[4] { "Too tired?", "Also too tired?", "How smart are you?", "How strong are you?" };
    private bool[] statSelections = new bool[4];
    private int statPointsToAllocate = 4;
    private int[] pointsToAllocate = new int[4];
    private int[] baseStatPoints = new int[4];
    private bool hasRunOnce = false;

    private string playerFirstName = "Enter First Name";
    private string playerLastName = "Enter Last Name";
    private string playerBio = "Enter Player Bio";
    private int genderSelection;
    private string[] genderTypes = new string[2] { "Male", "Female" };

	public void DisplayClassSelection()
    {
        classSelection = GUI.SelectionGrid(new Rect(50, 50, 250, 250), classSelection, classSelectionNames, 2);
        GUI.Label(new Rect(400, 50, 300, 300), FindClassDescription(classSelection));
        GUI.Label(new Rect(400, 100, 300, 300), FindClassStatValues(classSelection));
    }

    public void DisplayStatAllocation()
    {
        if (!hasRunOnce)
        {
            RetrieveStatBaseStatPoints();
            hasRunOnce = true;
        }

        for (int i = 0; i < statNames.Length; i++)
        {
            statSelections[i] = GUI.Toggle(new Rect(10, (60 * i + 10), 100, 50), statSelections[i], statNames[i]);
            GUI.Label(new Rect(100, (60 * i + 10), 50, 50), pointsToAllocate[i].ToString());

            if (statSelections[i])
            {
                GUI.Label(new Rect(20, 60*i+30, 150, 100), statDescription[i]);
            }
        }

        DisplayStatIncreaseDecreaseButton();
    }

    public void DisplayFinalSetup()
    {
        playerFirstName = GUI.TextArea(new Rect(20, 10, 150, 35), playerFirstName);
        playerLastName = GUI.TextArea(new Rect(20, 55, 150, 35), playerLastName);
        playerBio = GUI.TextArea(new Rect(20, 100, 250, 200), playerBio);
        genderSelection = GUI.SelectionGrid(new Rect(Screen.width - 125, 10, 100, 70), genderSelection, genderTypes, 1);
    }

    private void ChooseClass()
    {
        switch (classSelection)
        {
            case 0:
                GameInformation.PlayerClass = new BaseMageClass();
                break;
            case 1:
                GameInformation.PlayerClass = new BaseWarriorClass();
                break;
            default:
                break;

        }
    }

    public void DisplayMainItems()
    {
        switch (CreatePlayerGUI.currentState)
        {
            case CreatePlayerGUI.CreatePlayerStates.CLASS_SELECTION:
                GUI.Label(new Rect((Screen.width / 2), 20, 100, 100), "Class Selection");
                break;
            case CreatePlayerGUI.CreatePlayerStates.STAT_ALLOCATION:
                GUI.Label(new Rect((Screen.width / 2), 20, 100, 100), "Stat Allocation");
                break;
            case CreatePlayerGUI.CreatePlayerStates.FINAL_SETUP:
                GUI.Label(new Rect((Screen.width / 2), 20, 100, 100), "Final Step");
                break;
            default:
                break;
        }
        
        if (CreatePlayerGUI.currentState != CreatePlayerGUI.CreatePlayerStates.FINAL_SETUP)
        {
            if (GUI.Button(new Rect((Screen.width - 150), (Screen.height - 75), 100, 50), "Next"))
            {
                switch (CreatePlayerGUI.currentState)
                {
                    case CreatePlayerGUI.CreatePlayerStates.CLASS_SELECTION:
                        ChooseClass();
                        CreatePlayerGUI.currentState = CreatePlayerGUI.CreatePlayerStates.STAT_ALLOCATION;
                        break;
                    case CreatePlayerGUI.CreatePlayerStates.STAT_ALLOCATION:
                        CreatePlayerGUI.currentState = CreatePlayerGUI.CreatePlayerStates.FINAL_SETUP;
                        break;
                    case CreatePlayerGUI.CreatePlayerStates.FINAL_SETUP:
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            if (GUI.Button(new Rect((Screen.width - 150), (Screen.height - 75), 100, 50), "Finish"))
            {
                GameInformation.PlayerEndurance = pointsToAllocate[3];
                GameInformation.PlayerIntelligence = pointsToAllocate[2];
                GameInformation.PlayerStamina = pointsToAllocate[0];
                GameInformation.PlayerStrength = pointsToAllocate[1];
                GameInformation.PlayerName = playerFirstName + " " + playerLastName;
                GameInformation.PlayerIsMale = (genderSelection == 0);
                GameInformation.PlayerBio = playerBio;
                GameInformation.PlayerLevel = 1;
                SaveInformation.SaveAllInformation();
                Application.LoadLevel("test");
            }
        }

        if (CreatePlayerGUI.currentState != CreatePlayerGUI.CreatePlayerStates.CLASS_SELECTION)
        {
            if (GUI.Button(new Rect(50, (Screen.height - 75), 100, 50), "Previous"))
            {
                switch (CreatePlayerGUI.currentState)
                {
                    case CreatePlayerGUI.CreatePlayerStates.CLASS_SELECTION:
                        break;
                    case CreatePlayerGUI.CreatePlayerStates.STAT_ALLOCATION:
                        hasRunOnce = false;
                        CreatePlayerGUI.currentState = CreatePlayerGUI.CreatePlayerStates.CLASS_SELECTION;
                        break;
                    case CreatePlayerGUI.CreatePlayerStates.FINAL_SETUP:
                        CreatePlayerGUI.currentState = CreatePlayerGUI.CreatePlayerStates.STAT_ALLOCATION;
                        break;
                    default:
                        break;
                }
            }
        }
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

    private void DisplayStatIncreaseDecreaseButton()
    {
        for (int i = 0; i < pointsToAllocate.Length; i++)
        {
            if (pointsToAllocate[i] >= baseStatPoints[i] && statPointsToAllocate > 0)
            {
                if (GUI.Button(new Rect(260, (60 * i + 10), 50, 50), "+"))
                {
                    pointsToAllocate[i] += 1;
                    statPointsToAllocate--;
                }
            }

            if (pointsToAllocate[i] > baseStatPoints[i])
            {
                if (GUI.Button(new Rect(200, (60 * i + 10), 50, 50), "-"))
                {
                    pointsToAllocate[i] -= 1;
                    statPointsToAllocate++;
                }
            }
        }
    }

    private void RetrieveStatBaseStatPoints()
    {
        BaseCharacterClass tempClass = GameInformation.PlayerClass;

        pointsToAllocate[0] = tempClass.classStamina;
        pointsToAllocate[1] = tempClass.classStrength;
        pointsToAllocate[2] = tempClass.classIntelligence;
        pointsToAllocate[3] = tempClass.classEndurance;

        baseStatPoints[0] = tempClass.classStamina;
        baseStatPoints[1] = tempClass.classStrength;
        baseStatPoints[2] = tempClass.classIntelligence;
        baseStatPoints[3] = tempClass.classEndurance;
    }
}
