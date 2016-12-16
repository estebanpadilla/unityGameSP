
using UnityEngine;
using System.Collections;
class CargoDrone : Structure
{
    protected Stronghold stronghold;
    public Stronghold Stronghold { get { return this.stronghold; } set { this.stronghold = value; } }

    protected GameObject target;
    public GameObject Target { get { return this.target; } set { this.target = value; } }

    protected int cargo;
    public int Cargo { get { return this.cargo; } set { this.cargo = value; } }

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
        if (!isOn)
        {
            this.isOn = true;
            this.target = target;
            targetHT["position"] = target.transform.position;
            iTween.MoveTo(gameObject, targetHT);
        }
    }

    private void arrivedToTarget()
    {
        Debug.Log(("arrivedToTarget: " + this.target.name));
        iTween.MoveTo(gameObject, baseHT);
        Miner miner = target.GetComponent<Miner>();
        this.cargo = miner.droneArrived(this.data.storageCty);
    }

    private void arrivedToBase()
    {
        Debug.Log("arrivedToBase");
        this.stronghold.returnedToBase(this);
        this.target = null;
        this.isOn = false;
    }

    public int unloadCargo()
    {
        int load = this.cargo;
        this.cargo = 0;
        return load;
    }
}