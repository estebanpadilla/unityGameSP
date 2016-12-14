using UnityEngine;
class SolarStation : Structure
{

    void Start()
    {
        addRangeGameObject();
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        turnOn();
    }

    void Update()
    {
        //   "workTime": 2,
        //   "workRate": 2,
        //   "efficiency": 1,
        //   "deficiency": 0,
        //   "productionQty": 0,
        //   "storageCty": 50,

        if (!isOn)
        {
            return;
        }

        if (counter >= Data.workTime)
        {
            counter = 0;
            if (Data.productionQty < Data.storageCty)
            {
                Data.productionQty += Data.workRate;
            }
            // else
            // {
            //isWorking = false;
            // }
        }
        else
        {
            counter += (Time.deltaTime * Data.efficiency);
        }
    }

    public override int sendEnergy(int requestedEnergy)
    {
        //isWorking = true;

        if (Data.productionQty >= requestedEnergy)
        {
            Data.productionQty -= requestedEnergy;
            return requestedEnergy;
        }
        else if (false)
        {
            //check is energy storage structure is connected and send energy from there.
            return 0;
        }

        Debug.Log(("No energy available" + gameObject.name));
        return 0;
    }

    public override void turnOn()
    {
        isOn = true;
    }

    public override void turnOff()
    {
        isOn = false;
    }


}