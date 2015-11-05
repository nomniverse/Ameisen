using UnityEngine;
using System.Collections;
using Assets.Scripts;

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
        newWeapon.itemStats[Constants.STAMINA_INDEX].statBaseValue = Random.Range(1, 11);
        newWeapon.itemStats[Constants.ENDURANCE_INDEX].statBaseValue = Random.Range(1, 11);
        newWeapon.itemStats[Constants.STRENGTH_INDEX].statBaseValue = Random.Range(1, 11);
        newWeapon.itemStats[Constants.INTELLIGENCE_INDEX].statBaseValue = Random.Range(1, 11);
        newWeapon.spellEffectID = Random.Range(1, 101);
    }

    private void ChooseWeaponType()
    {
        System.Array weapons = System.Enum.GetValues(typeof(BaseWeapon.WeaponType));
        newWeapon.weaponType = (BaseWeapon.WeaponType)weapons.GetValue(Random.Range(0, weapons.Length));
    }
}
