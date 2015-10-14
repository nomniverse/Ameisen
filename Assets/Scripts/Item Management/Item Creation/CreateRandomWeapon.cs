using UnityEngine;
using System.Collections;

public class CreateRandomWeapon : MonoBehaviour {

    private BaseWeapon newWeapon;

    // Use this for initialization
    void Start()
    {
        CreateWeapon();
        Debug.Log(newWeapon.itemName);
        Debug.Log(newWeapon.itemDescription);
        Debug.Log(newWeapon.itemID.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateWeapon()
    {
        newWeapon = new BaseWeapon();

        // Item info assignment
        newWeapon.itemName = "W-" + Random.Range(1, 101);
        newWeapon.itemDescription = "Randomly generated weapon";
        newWeapon.itemID = Random.Range(1, 101);
        ChooseWeaponType();

        // Stat assignment
        newWeapon.classStamina = Random.Range(1, 11);
        newWeapon.classEndurance = Random.Range(1, 11);
        newWeapon.classIntelligence = Random.Range(1, 11);
        newWeapon.classStrength = Random.Range(1, 11);
        newWeapon.spellEffectID = Random.Range(1, 101);
    }

    private void ChooseWeaponType()
    {
        int random = Random.Range(1, 3);
        
        switch (random)
        {
            case 1:
                newWeapon.weaponType = BaseWeapon.WeaponType.Melee;
                break;
            case 2:
                newWeapon.weaponType = BaseWeapon.WeaponType.Ranged;
                break;
            default:
                break;
        }
    }
}
