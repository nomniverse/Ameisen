using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	//Create Menu Control Variables
	public bool main;
	public bool paused = false;
	private bool settings = false;
	private bool keys = false;
	private bool sound = false;
	private bool video = false;


	private float musicVolume = 50;
	private float sfxVolume = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnGUI() {
		string baseMenu = "Main";

		if (main) {
			baseMenu = "Main";

			//Creates a button to start the game
			if(GUI.Button(new Rect((Screen.width/2) - 50, 50, 100, 50), "Start Game")){
				//Starts the game by opening the first scene
			}
			//Creates a button to enter the options menu
			if(GUI.Button(new Rect((Screen.width/2) - 50, 100, 100, 50), "Options")){
			   settings = true;
			   main = false;
			}
			//Creates a button to exit the game
			if(GUI.Button(new Rect((Screen.width/2) - 50, (Screen.height/2) + 25, 100, 50), "Exit Game")){
				//Stops the game
			}
		}

		if (paused) {
			baseMenu = "Paused";

			//Creates a button to resume the game
			if(GUI.Button(new Rect((Screen.width/2) - 50, (Screen.height/2) + 25, 100, 50), "Resume Game")){
				//Unpauses game
			}
			//Creates a button to enter the options menu
			if(GUI.Button(new Rect((Screen.width/2) - 50, (Screen.height/2) - 25, 100, 50), "Options")){
				settings = true;
				paused = false;
			}
			//Creates a button to exit the game
			if(GUI.Button(new Rect((Screen.width/2) - 50, 50, 100, 50), "Exit Game")){
				//Stops the game
			}
		}

		if (settings) {
			//Creates a button to enter the keybinding menu
			if (GUI.Button (new Rect ((Screen.width / 2) - 50, 0, 100, 50), "Keybindings")) {
					keys = true;
					settings = false;
			}
			//Creates a button to enter the sound menu
			if (GUI.Button (new Rect ((Screen.width / 2) - 50, (Screen.height / 2 - 75), 100, 50), "Audio Settings")) {
					sound = true;
					settings = false;
			}
			//Creates a button to enter the video menu
			if (GUI.Button (new Rect ((Screen.width / 2) - 50, (Screen.height - 150), 100, 50), "Video Settings")) {
					video = true;
					settings = false;
			}
			//Creates a back button
			if (GUI.Button (new Rect ((Screen.width / 2) - 50, (Screen.height - 50), 100, 50), "Back")) {
					switch (baseMenu) {
					case "Main":
							main = true;
							settings = false;
							break;
					case "Paused":
							paused = true;
							settings = false;
							break;
					}
			}
		}

		if (sound) {
			//Creates a horizontal slider for music volume
			GUI.Label (new Rect((Screen.width / 2) - 50, (Screen.height / 2) - 25, 150, 25), "Music Volume");
			musicVolume = GUI.HorizontalSlider (new Rect ((Screen.width / 2) - 50, (Screen.height / 2) + 5, 100, 10), musicVolume, 0, 100);

			//Creates a horizontal slider for SFX volume
			GUI.Label (new Rect((Screen.width / 2) - 50, 50, 150, 25), "SFX Volume");
			sfxVolume = GUI.HorizontalSlider (new Rect ((Screen.width / 2) - 50, 75, 100, 10), sfxVolume, 0, 100);

			//Creates a save button for the sound options
			if (GUI.Button (new Rect ((Screen.width / 2) + 50, Screen.height - 50, 100, 50), "Save")) {
					//Code to save will need to work xml files
			}

			//Creates a back button to get to the options menu
			if (GUI.Button (new Rect ((Screen.width / 2) - 150, Screen.height - 50, 100, 50), "Back")) {
					sound = false;
					settings = true;
			}
		}

		if (video) {
			//Creates a horizontal slider for FoV, which does not exist because it is top down
			GUI.Label(new Rect((Screen.width/2) - 150, 50, 300, 25), "Useless FoV sldier (Impresses critics)");
			musicVolume = GUI.HorizontalSlider(new Rect((Screen.width/2) - 50, 75, 100, 10), 50, 0, 100);

			//Creates a save button for the video options
			if(GUI.Button(new Rect((Screen.width/2) + 50, Screen.height - 50, 100, 50), "Save")) {
				//Code to save will need to work xml files
			}
			
			//Creates a back button to get to the options menu
			if(GUI.Button(new Rect((Screen.width/2) - 150, Screen.height - 50, 100, 50), "Back")) {
				video = false;
				settings = true;
			}
		}
	}
}
