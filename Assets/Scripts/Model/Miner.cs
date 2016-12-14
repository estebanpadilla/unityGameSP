using UnityEngine;
class Miner : Structure
{
    private int energy = 0;

    void Start()
    {
        addRangeGameObject();
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        turnOn();
    }

    void OnMouseUpAsButton()
    {
        Debug.Log("request energy");
        energy = this.requestEnergy(Data.energyRequire);
        Debug.Log(energy);

    }

    void Update()
    {
        /*
        if (isRequestingEnergy)
        {
            Debug.Log(("request energy: " + gameObject.name));
            energy = this.requestEnergy(Data.energyRequire);
            Debug.Log(("received energy: " + energy));
            isRequestingEnergy = false;
            return;
        }

        if (!isOn)
        {
            return;
        }

        if (energy == Data.energyRequire)
        {
            if (counter >= Data.workTime)
            {
                counter = 0;
                energy = 0;

                if (Data.productionQty < Data.storageCty)
                {
                    Data.productionQty += Data.workRate;

                }
                else
                {
                    isOn = false;
                }
            }
            else
            {
                counter += (Time.deltaTime * Data.efficiency);
            }
        }
        else
        {
            isRequestingEnergy = true;
        }
        */
    }

    public override void turnOn()
    {
        isOn = true;
        work();
    }

    public override void turnOff()
    {
        isOn = false;
    }

    public override void work()
    {
        this.energy = requestEnergy(this.Data.energyRequire);
        if (this.energy == this.Data.energyRequire)
        {
            Invoke("workComplete", this.Data.workTime);
        }
        else
        {
            if (this.isOn)
            {
                Invoke("work", 5.0f);
            }
            else
            {
                Debug.Log(("Miner is off " + gameObject.name));
            }
        }
    }

    public override void workComplete()
    {
        if (Data.productionQty < Data.storageCty)
        {
            Data.productionQty += (Data.workRate * Data.efficiency);
            Invoke("work", 1.0f);
        }
        else
        {
            Debug.Log(("NO MORE ROOM FOR MATERIAL ON " + gameObject.name));
        }
    }
}