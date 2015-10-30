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
        System.Array consumerables = System.Enum.GetValues(typeof(BaseConsumerable.ConsumerableType));
        newConsumerable.consumerableType = (BaseConsumerable.ConsumerableType)consumerables.GetValue(Random.Range(0, consumerables.Length));
    }
}
