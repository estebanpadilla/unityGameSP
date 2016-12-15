using UnityEngine;
class SolarStation : Structure
{

    void Start()
    {
        addRangeGameObject();
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        //turnOn();
    }

    void Update()
    {
        // if (!isOn)
        // {
        //     return;
        // }

        // if (counter >= Data.workTime)
        // {
        //     counter = 0;
        //     if (Data.productionQty < Data.storageCty)
        //     {
        //         Data.productionQty += Data.workRate;
        //     }
        // }
        // else
        // {
        //     counter += (Time.deltaTime * Data.efficiency);
        // }
    }

    public override int sendEnergy(int requestedEnergy)
    {
        //isWorking = true;

        if (this.useProduction(requestedEnergy))
        {
            return requestedEnergy;
        }
        else if (storageStructures.Count > 0)
        {
            //check is energy storage structure is connected and send energy from there.
            foreach (GameObject batteryGO in storageStructures.Values)
            {
                Structure battery = batteryGO.GetComponent<Structure>();
                if (battery.useProduction(requestedEnergy))
                {
                    return requestedEnergy;
                }
                // else
                // {
                //     Debug.Log(("no energy in battery: " + battery.name));
                // }
            }
        }
        // else
        // {
        //     Debug.Log(("no battery in solarStation: " + gameObject.name));
        // }

        //Debug.Log(("No energy available" + gameObject.name));
        return 0;
    }

    public override void turnOn()
    {
        //Debug.Log(("turnOn: " + gameObject.name));
        this.isOn = true;
        this.work();
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public override void turnOff()
    {
        //Debug.Log(("turnOff: " + gameObject.name));
        this.isOn = false;
        CancelInvoke();
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    public override void work()
    {
        if (!IsInvoking("workComplete"))
        {
            //Debug.Log(("work on " + gameObject.name));
            this.Invoke("workComplete", Data.workTime);
        }

    }

    public override void workComplete()
    {
        if (saveProduction(Data.workRate))
        {
            //Debug.Log(("add energy" + gameObject.name));
            this.work();
        }
        else if (storageStructures.Count > 0)
        {
            bool isEnergySaved = false;

            foreach (GameObject batteryGO in storageStructures.Values)
            {
                Structure battery = batteryGO.GetComponent<Structure>();
                isEnergySaved = battery.saveProduction(Data.workRate);

                if (isEnergySaved)
                {
                    this.work();
                    return;
                }
                // else
                // {
                // Debug.Log(("battery is full: " + battery.name));
                // }
            }

            if (!isEnergySaved)
            {
                this.turnOff();
                //Debug.Log("All batteries are full:");
            }
        }
        else
        {
            //Debug.Log("Storage capacity reached and not bateries connected.");
            this.turnOff();
        }
    }



    public override void addStorageStructure(GameObject value)
    {
        if (value.name != gameObject.name)
        {
            if (!this.storageStructures.ContainsKey(value.name))
            {
                //Debug.Log(("Add storaje " + storageStructure.name + "to " + gameObject.name));
                this.storageStructures.Add(value.name, value);
                if (this.isOn)
                {
                    this.work();
                }
                else
                {
                    this.turnOn();
                }
            }
        }
    }

    public override void removeStorageStructure(GameObject value)
    {
        if (this.storageStructures.ContainsKey(value.name))
        {
            this.storageStructures.Remove(value.name);
        }
    }

    public override bool saveProduction(int value)
    {
        if ((this.Data.productionQty + value) <= this.Data.storageCty)
        {
            this.Data.productionQty += value;
            return true;
        }
        return false;
    }

    public override bool useProduction(int value)
    {
        if (this.Data.productionQty >= value)
        {
            this.turnOn();
            this.Data.productionQty -= value;
            return true;
        }
        return false;
    }
}