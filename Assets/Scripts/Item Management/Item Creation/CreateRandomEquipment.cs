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
        newEquipment.staminaModifier = Random.Range(1, 11);
        newEquipment.enduranceModifier = Random.Range(1, 11);
        newEquipment.intelligenceModifier = Random.Range(1, 11);
        newEquipment.strengthModifier = Random.Range(1, 11);
        newEquipment.spellEffectID = Random.Range(1, 101);
    }

    private void ChooseEquipmentType()
    {
        System.Array equipments = System.Enum.GetValues(typeof(BaseEquipment.EquipmentType));
        newEquipment.equipmentType = (BaseEquipment.EquipmentType)equipments.GetValue(Random.Range(0, equipments.Length));
    }
}
