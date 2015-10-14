using UnityEngine;
using System.Collections;

public class CreateRandomEquipment : MonoBehaviour {

    private BaseEquipment newEquipment;

    private string[] names = new string[4] { "Poor", "Common", "Special", "Godly" };

	// Use this for initialization
	void Start () {
        CreateEquipment();
        Debug.Log(newEquipment.itemName);
        Debug.Log(newEquipment.itemDescription);
        Debug.Log(newEquipment.itemID.ToString());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CreateEquipment()
    {
        newEquipment = new BaseEquipment();

        // Item info assignment
        newEquipment.itemName = names[Random.Range(0, names.Length)] + " Equipment";
        newEquipment.itemDescription = "Randomly generated weapon";
        newEquipment.itemID = Random.Range(1, 101);
        ChooseEquipmentType();

        // Stat assignment
        newEquipment.classStamina = Random.Range(1, 11);
        newEquipment.classEndurance = Random.Range(1, 11);
        newEquipment.classIntelligence = Random.Range(1, 11);
        newEquipment.classStrength = Random.Range(1, 11);
        newEquipment.spellEffectID = Random.Range(1, 101);
    }

    private void ChooseEquipmentType()
    {
        int random = Random.Range(1, 5);

        switch (random)
        {
            case 1:
                newEquipment.equipmentType = BaseEquipment.EquipmentType.Head;
                break;
            case 2:
                newEquipment.equipmentType = BaseEquipment.EquipmentType.Chest;
                break;
            case 3:
                newEquipment.equipmentType = BaseEquipment.EquipmentType.Legs;
                break;
            case 4:
                newEquipment.equipmentType = BaseEquipment.EquipmentType.Feet;
                break;
            default:
                break;
        }
    }
}
