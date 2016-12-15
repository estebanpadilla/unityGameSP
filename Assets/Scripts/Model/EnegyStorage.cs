using UnityEngine;
class EnegyStorage : Structure
{

    void Start()
    {
        addRangeGameObject();
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    public override bool saveProduction(int value)
    {
        if ((Data.productionQty + value) <= Data.storageCty)
        {
            Data.productionQty += value;
            return true;
        }
        return false;
    }

    public override bool useProduction(int value)
    {
        if (Data.productionQty >= value)
        {
            Data.productionQty -= value;
            return true;
        }
        return false;
    }
}