using UnityEngine;
using System.Collections;

public class BaseConsumerable : BaseStatItem {

	public enum ConsumerableType
    {
        Potion,
        Food,
        Drink
    }

    private ConsumerableType cType;
    private int effectID;

    public ConsumerableType consumerableType
    {
        get { return cType; }
        set { cType = value; }
    }

    public int spellEffectID
    {
        get { return effectID; }
        set { effectID = value; }
    }
}
