using UnityEngine;
class Miner : Structure
{
    private int energy = 0;
    protected bool isDroneRequested = false;
    protected bool isDroneSent = false;
    public bool IsDroneRequested { get { return this.isDroneRequested; } set { this.isDroneRequested = value; } }
    public bool IsDroneSent { get { return this.isDroneSent; } set { this.isDroneSent = value; } }

    void Start()
    {
        addRangeGameObject();
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    void OnMouseUpAsButton()
    {
        // Debug.Log("reset production");
        // this.data.productionQty = 0;
        // this.isDroneRequested = false;
        // this.isDroneSent = false;
        // work();
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
        this.isOn = true;
        this.work();
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public override void turnOff()
    {
        this.isOn = false;
        CancelInvoke();
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    public override void work()
    {
        //Request energy and if enegy is received then it will invoke the methods workComplete else
        //it will wait some time to try again.
        if (this.mineralSources.Count > 0)
        {
            this.energy = requestEnergy(this.Data.energyRequire);
            if (this.energy == this.Data.energyRequire && !IsInvoking("workComplete"))
            {

                bool didMinedAsteroid = false;

                foreach (GameObject item in this.mineralSources.Values)
                {
                    Structure asteroid = item.GetComponent<Structure>();
                    didMinedAsteroid = asteroid.useProduction(Data.workRate);

                    if (didMinedAsteroid)
                    {
                        Invoke("workComplete", this.Data.workTime);
                        break;
                    }
                }

                if (!didMinedAsteroid)
                {
                    this.turnOff();
                    Debug.Log("All asteroids mined");
                }

            }
            else
            {
                if (this.isOn && !IsInvoking("work"))
                {
                    Debug.Log(("TRY AGAIN IN 5 SECONDS: " + gameObject.name));
                    this.turnOff();
                    this.Invoke("turnOn", 5.0f);
                }
                else
                {
                    Debug.Log(("Miner is off " + gameObject.name));
                }
            }
        }
        else
        {
            Debug.Log(("NO ASTEROIDS IN" + gameObject.name));
        }
    }

    public override void workComplete()
    {
        if (this.saveProduction(this.Data.workRate))
        {
            this.work();
        }
        else
        {
            this.turnOff();
            Debug.Log(("NO MORE ROOM FOR MATERIAL ON " + gameObject.name));
            requestDrone();
            Debug.Log(("Requesting drome on " + gameObject.name));
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
            this.Data.productionQty -= value;
            return true;
        }
        return false;
    }

    private void requestDrone()
    {
        if (!isDroneRequested)
        {
            this.isDroneRequested = true;
            this.gameManager.requestDrone(gameObject);
        }
    }

    public int droneArrived(int cargoRequired)
    {
        this.data.productionQty -= cargoRequired;
        this.isDroneSent = false;
        this.isDroneRequested = false;
        this.turnOn();
        return cargoRequired;
    }
}