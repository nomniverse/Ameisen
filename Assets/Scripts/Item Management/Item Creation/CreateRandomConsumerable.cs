using UnityEngine;
using System.Collections;

public class CreateRandomConsumerable : MonoBehaviour {

    private BaseConsumerable newConsumerable;

	// Use this for initialization
	void Start () {
        CreateConsumerable();
        Debug.Log(newConsumerable.itemName);
        Debug.Log(newConsumerable.itemDescription);
        Debug.Log(newConsumerable.itemID.ToString());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CreateConsumerable()
    {
        newConsumerable = new BaseConsumerable();
        newConsumerable.itemName = "Consumerable";
        newConsumerable.itemDescription = "This is consumable";
        newConsumerable.itemID = Random.Range(1, 101);
        newConsumerable.spellEffectID = Random.Range(1, 101);
        ChooseConsumerableType();
    }

    private void ChooseConsumerableType()
    {
        int random = Random.Range(1, 4);

        switch(random)
        {
            case 1:
                newConsumerable.consumerableType = BaseConsumerable.ConsumerableType.Drink;
                break;
            case 2:
                newConsumerable.consumerableType = BaseConsumerable.ConsumerableType.Potion;
                break;
            case 3:
                newConsumerable.consumerableType = BaseConsumerable.ConsumerableType.Food;
                break;
            default:
                break;
        }
    }
}
