using UnityEngine;
class EnegyStorage : Structure
{

    void Start()
    {
        this.connectionIndex = ConnectionCounter;
        addRangeGameObject();
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    public override void turnOn()
    {
        this.isOn = true;
        removeHigherConnections();
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public override void turnOff()
    {
        this.isOn = false;
        CancelInvoke();
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