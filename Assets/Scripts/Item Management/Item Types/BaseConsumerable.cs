using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseConsumerable : BaseStatItem {

	public enum ConsumerableType
    {
        Potion,
        Food,
        Drink
    }

    public ConsumerableType consumerableType { get; set; }

    public int spellEffectID { get; set; }
}
