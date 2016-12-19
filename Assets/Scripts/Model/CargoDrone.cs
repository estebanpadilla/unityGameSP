
using UnityEngine;
using System.Collections;
class CargoDrone : Structure
{
    private int energy = 0;
    protected Stronghold stronghold;
    public Stronghold Stronghold { get { return this.stronghold; } set { this.stronghold = value; } }

    protected GameObject target;
    public GameObject Target { get { return this.target; } set { this.target = value; } }

    protected float cargo;
    public float Cargo { get { return this.cargo; } set { this.cargo = value; } }

    private float speed = 2.0f;
    private float delay = 2.0f;

    Vector3 basePosition;

    Hashtable targetHT = new Hashtable();
    Hashtable baseHT = new Hashtable();

    void Start()
    {
        basePosition = transform.position;

        targetHT.Add("name", "targetHT");
        targetHT.Add("oncomplete", "arrivedToTarget");
        targetHT.Add("position", Vector3.zero);
        targetHT.Add("speed", speed);
        targetHT.Add("easetype", iTween.EaseType.easeInOutSine);

        baseHT.Add("name", "targetHT");
        baseHT.Add("oncomplete", "arrivedToBase");
        baseHT.Add("position", basePosition);
        baseHT.Add("speed", speed);
        baseHT.Add("delay", delay);
        baseHT.Add("easetype", iTween.EaseType.easeInOutSine);

        this.workComplete();

    }

    void Update()
    {
        // if (move)
        // {

        //     float step = speed * Time.deltaTime;
        //     gameObject.transform.position = Vector3.MoveTowards(transform.position, moveVector, step);

        //     if (gameObject.transform.position == moveVector)
        //     {
        //         move = false;
        //         Debug.Log("reached destination");
        //     }
        // }

    }


    public void moveTo(GameObject target)
    {
        this.target = target;
        turnOn();
    }

    private void arrivedToTarget()
    {
        //Debug.Log(("arrivedToTarget: " + this.target.name));
        iTween.MoveTo(gameObject, baseHT);
        Miner miner = target.GetComponent<Miner>();
        transform.LookAt(transform.position + (new Vector3(0, 0, 1)), basePosition);
        this.cargo = miner.droneArrived(this.data.storageCty);
    }

    private void arrivedToBase()
    {
        //Debug.Log("arrivedToBase");
        this.stronghold.returnedToBase(this);
        this.target = null;
        this.workComplete();
    }

    public float unloadCargo()
    {
        float load = this.cargo;
        this.cargo = 0;
        return load;
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

        // this.energy = stronghold.requestEnergy(this.Data.energyRequire);
        // if (this.energy == this.Data.energyRequire && !IsInvoking("workComplete"))
        // {
        targetHT["position"] = target.transform.position;
        iTween.MoveTo(gameObject, targetHT);
        transform.LookAt(transform.position + (new Vector3(0, 0, 1)), target.transform.position);
        // }
        // else
        // {
        //     if (this.isOn && !IsInvoking("work"))
        //     {
        //         Debug.Log(("TRY AGAIN IN 5 SECONDS: " + gameObject.name));
        //         this.turnOff();
        //         this.Invoke("turnOn", 5.0f);
        //     }
        //     else
        //     {
        //         Debug.Log(("Drone is off " + gameObject.name));
        //     }
        // }
    }

    public override void workComplete()
    {
        chargeEnergy();
        this.isOn = true;
        if (this.energy == this.Data.energyRequire && !IsInvoking("workComplete"))
        {
            this.turnOff();
        }
        else
        {
            //Debug.Log("Batteries low in drone, waiting 5 seconds");
            Invoke("workComplete", 5);
        }
    }

    private void chargeEnergy()
    {
        this.energy = stronghold.requestEnergy(this.Data.energyRequire);
    }
}