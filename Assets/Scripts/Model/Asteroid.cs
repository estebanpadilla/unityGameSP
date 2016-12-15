using UnityEngine;
public class Asteroid : Structure
{
    void Start()
    {
        isAlwaysDragable = true;
    }

    public override bool useProduction(int value)
    {
        if (this.Data.productionQty >= value)
        {
            this.Data.productionQty -= value;
            return true;
        }

        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        return false;
    }
}
