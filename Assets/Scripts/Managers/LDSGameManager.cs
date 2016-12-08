using UnityEngine;
using System.Collections.Generic;

public class LDSGameManager : MonoBehaviour
{
    //Game objects
    public GameObject uiManagerPref;
    public GameObject strongholdPref;
    public GameObject solarStationPref;
    public GameObject batteryPref;
    public GameObject relayPref;
    public GameObject repairStationPref;
    public GameObject repairDromePref;
    public GameObject minerPref;
    public GameObject asteroidPref;

    private LDSDataManager dataManager;
    private LDSUIManager uiManager;
    public Player player;

    private int objectCounter = 0;
    private Dictionary<string, GameObject> pool = new Dictionary<string, GameObject>();
    public Dictionary<string, GameObject> Pool { get { return this.pool; } set { this.pool = value; } }

    void Awake()
    {
        this.dataManager = new LDSDataManager();
        this.dataManager.loadLDSObjectsData();
        this.player = new Player();
    }

    void Start()
    {
        Debug.Log("LDSGameManager Star()");

        GameObject go = Instantiate(uiManagerPref, Vector3.zero, Quaternion.identity);
        uiManager = go.GetComponent<LDSUIManager>();

        createObject("stronghold");

        // LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        // lineRenderer.widthMultiplier = 0.2f;
        // lineRenderer.numPositions = 2;	
        // lineRenderer.SetPosition(0, new Vector3(0, 0, -1));
        // lineRenderer.SetPosition(1, new Vector3(5, 5, -1));
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawLine(Vector3.zero, new Vector3(1, 2, 0), Color.yellow);
    }

    public void addSolarStation()
    {
        createObject("solarStation1");
    }

    public void addBattery()
    {
        createObject("battery1");
    }

    public void addRelay()
    {
        createObject("relay1");
    }

    public void addRepairStation()
    {
        createObject("repairStation1");
    }

    public void addMiner()
    {
        createObject("miner1");
    }

    public void setCurrentObjectToDisplay(Structure value)
    {
        this.uiManager.CurrentObject = value;
    }

    private void createObject(string value)
    {

        LDSData data = dataManager.findGameObjectData(value);

        if (player.hasEnoughCash(data.price))
        {

            GameObject go;
            Structure script;
            string name = string.Concat(value, "_", objectCounter);

            switch (value)
            {
                case "stronghold":
                    go = Instantiate(strongholdPref, Vector3.zero, Quaternion.identity);
                    pool.Add(name, go);
                    script = go.GetComponent<Stronghold>();
                    break;
                case "solarStation1":
                    go = Instantiate(solarStationPref, Vector3.zero, Quaternion.identity);
                    pool.Add(name, go);
                    script = go.GetComponent<SolarStation>();
                    break;
                case "battery1":
                    go = Instantiate(batteryPref, Vector3.zero, Quaternion.identity);
                    pool.Add(name, go);
                    script = go.GetComponent<Battery>();
                    break;
                case "relay1":
                    go = Instantiate(relayPref, Vector3.zero, Quaternion.identity);
                    pool.Add(name, go);
                    script = go.GetComponent<Relay>();
                    break;
                case "repairStation1":
                    go = Instantiate(repairStationPref, Vector3.zero, Quaternion.identity);
                    pool.Add(name, go);
                    script = go.GetComponent<RepairStation>();
                    break;
                case "miner1":
                    go = Instantiate(minerPref, Vector3.zero, Quaternion.identity);
                    pool.Add(name, go);
                    script = go.GetComponent<Miner>();
                    break;
                default:
                    go = null;
                    script = null;
                    break;
            }

            if (go != null)
            {
                go.name = name;
                script.Data = data;
                script.GameManager = this;
                objectCounter++;
            }
        }
    }

    public void findConnections(Vector3 position)
    {
        foreach (GameObject item in Pool.Values)
        {
            Debug.DrawLine(item.transform.position, position, Color.yellow);
        }
    }
}
