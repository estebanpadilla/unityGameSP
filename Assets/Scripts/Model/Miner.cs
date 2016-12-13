using UnityEngine;
class Miner : Structure
{
    private int energy = 0;

    void Start()
    {
        isWorking = true;
        addRangeGameObject();
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    void OnMouseUpAsButton()
    {
        Debug.Log("request energy");
        energy = this.requestEnergy(Data.energyUsage);
        Debug.Log(energy);
    }

    void Update()
    {
        if (!isWorking)
        {
            return;
        }

        if (energy == Data.energyUsage)
        {
            if (counter >= Data.workTime)
            {
                counter = 0;
                if (Data.productionQty < Data.storageCty)
                {
                    Data.productionQty += Data.workRate;

                }
                else
                {
                    isWorking = false;
                }
            }
            else
            {
                counter += (Time.deltaTime * 3) * Data.efficiency;
            }
        }
        else
        {
            energy = this.requestEnergy(Data.energyUsage);
        }
    }
}