using UnityEngine;
using System.Collections;

public class ClassGUI : MonoBehaviour {

    private BaseCharacterClass class1 = new BaseMageClass();
    private BaseCharacterClass class2 = new BaseWarriorClass();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUILayout.Label(class1.className);
        GUILayout.Label(class1.classDescription);

        GUILayout.Label(class2.className);
        GUILayout.Label(class2.classDescription);
    }
}
