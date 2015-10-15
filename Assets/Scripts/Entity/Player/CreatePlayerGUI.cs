using UnityEngine;
using System.Collections;

public class CreatePlayerGUI : MonoBehaviour {

    public enum CreatePlayerStates
    {
        CLASS_SELECTION,
        STAT_ALLOCATION,
        FINAL_SETUP
    }

    public static CreatePlayerStates currentState;
    private DisplayCreatePlayerFunctions displayFunctions = new DisplayCreatePlayerFunctions();

	// Use this for initialization
	void Start () {
        currentState = CreatePlayerStates.CLASS_SELECTION;
	}
	
	// Update is called once per frame
	void Update () {
	    switch (currentState)
        {
            case CreatePlayerStates.CLASS_SELECTION:
                break;
            case CreatePlayerStates.STAT_ALLOCATION:
                break;
            case CreatePlayerStates.FINAL_SETUP:
                break;
            default:
                break;
        }
	}

    void OnGUI()
    {
        displayFunctions.DisplayMainItems();
        switch (currentState)
        {
            case CreatePlayerStates.CLASS_SELECTION:
                displayFunctions.DisplayClassSelection();
                break;
            case CreatePlayerStates.STAT_ALLOCATION:
                displayFunctions.DisplayStatAllocation();
                break;
            case CreatePlayerStates.FINAL_SETUP:
                displayFunctions.DisplayFinalSetup();
                break;
            default:
                break;
        }
    }
}
