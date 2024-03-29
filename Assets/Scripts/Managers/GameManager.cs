﻿using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    //Prefabs declarations
    //Game managers
    public GameObject uiManagerPref;

    //Player game objects
    public GameObject strongholdPref;
    public GameObject solarStationPref;
    public GameObject materialStoragePref;
    public GameObject cargoDronePref;
    public GameObject materialContainerPref;
    public GameObject enegyStoragePref;
    public GameObject relayPref;
    public GameObject repairStationPref;
    public GameObject repairDromePref;
    public GameObject minerPref;
    public GameObject laserPref;
    public GameObject missileLauncherPref;

    //Level game objects
    public GameObject asteroid1Pref;
    public GameObject asteroid2Pref;
    public GameObject asteroid3Pref;
    public GameObject asteroid4Pref;
    public GameObject asteroid5Pref;

    //Instance Variables
    protected DataManager dataManager;
    public DataManager DataManager { get { return this.dataManager; } set { this.dataManager = value; } }

    private UIManager uiManager;
    public Player player;
    private GameObject stronghold;

    protected int objectCounter = 0;
    public int ObjectCounter { get { return this.objectCounter; } set { this.objectCounter = value; } }
    private Dictionary<string, GameObject> pool = new Dictionary<string, GameObject>();
    public Dictionary<string, GameObject> Pool { get { return this.pool; } set { this.pool = value; } }

    public bool disableCameraMove = false;

    void Awake()
    {
        this.dataManager = new DataManager();
        this.dataManager.loadGameObjectsData();
        this.dataManager.loadGameLevelsData();
        this.player = new Player();
        createLevelObjects();
    }

    void Start()
    {
        Debug.Log("LDSGameManager Star()");

        GameObject go = Instantiate(uiManagerPref, Vector3.zero, Quaternion.identity);
        uiManager = go.GetComponent<UIManager>();

        createObject("stronghold", Vector3.zero, false);

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
        createObject("solarStation1", Vector3.zero, true);
    }

    public void addEnegyStorage()
    {
        createObject("enegyStorage1", Vector3.zero, true);
    }

    public void addMineralStorage()
    {
        createObject("mineralStorage1", Vector3.zero, true);
    }

    public void addCargoContainer()
    {
        createObject("cargoContainer", Vector3.zero, false);
    }

    public void addCargoContainerWithPosition(Vector3 position)
    {
        createObject("cargoContainer", position, false);
    }

    public void addCargoDrone()
    {
        createObject("cargoDrone1", Vector3.zero, false);
    }

    public void addCargoDroneWithPosition(Vector3 position)
    {
        createObject("cargoDrone1", position, false);
    }

    public void addRelay()
    {
        createObject("relay1", Vector3.zero, true);
    }

    public void addRepairStation()
    {
        createObject("repairStation1", Vector3.zero, true);
    }

    public void addMiner()
    {
        createObject("miner1", Vector3.zero, true);
    }

    public void addAsteroid(int value)
    {
        switch (value)
        {
            case 1:
                createObject("asteroid1", Vector3.zero, false);
                break;
            case 2:
                createObject("asteroid2", Vector3.zero, false);
                break;
            case 3:
                createObject("asteroid3", Vector3.zero, false);
                break;
            case 4:
                createObject("asteroid4", Vector3.zero, false);
                break;
            case 5:
                createObject("asteroid5", Vector3.zero, false);
                break;
            default:
                createObject("asteroid1", Vector3.zero, false);
                break;
        }
    }

    public void addLaser()
    {
        createObject("laser1", Vector3.zero, true);
    }

    public void addMissileLauncher()
    {
        createObject("missileLauncher1", Vector3.zero, true);
    }

    public void setCurrentObjectToDisplay(Structure value)
    {
        this.uiManager.CurrentObject = value;
    }

    private void createObject(string value, Vector3 position, bool doPriceCheck)
    {

        GameObjectData data = dataManager.findGameObjectData(value).Clone();

        bool canPlayerPurchaseObject = false;

        if (doPriceCheck)
        {
            if (player.hasEnoughCash(data.price))
            {
                canPlayerPurchaseObject = true;
            }
        }
        else
        {
            canPlayerPurchaseObject = true;
        }

        if (canPlayerPurchaseObject)
        {

            GameObject go;
            Structure script;
            string name = string.Concat(value, "_", objectCounter);

            switch (value)
            {
                case "stronghold":
                    go = Instantiate(strongholdPref, position, Quaternion.identity);
                    stronghold = go;
                    pool.Add(name, go);
                    script = go.GetComponent<Stronghold>();
                    break;
                case "solarStation1":
                    go = Instantiate(solarStationPref, position, Quaternion.identity);
                    pool.Add(name, go);
                    script = go.GetComponent<SolarStation>();
                    break;
                case "enegyStorage1":
                    go = Instantiate(enegyStoragePref, position, Quaternion.identity);
                    pool.Add(name, go);
                    script = go.GetComponent<EnegyStorage>();
                    break;
                case "mineralStorage1":
                    go = Instantiate(materialStoragePref, position, Quaternion.identity);
                    pool.Add(name, go);
                    script = go.GetComponent<MineralStorage>();
                    break;
                case "cargoContainer":
                    go = Instantiate(materialContainerPref, position, Quaternion.identity);
                    pool.Add(name, go);
                    script = go.GetComponent<CargoContainer>();
                    break;
                case "cargoDrone1":
                    go = Instantiate(cargoDronePref, position, Quaternion.identity);
                    pool.Add(name, go);
                    script = go.GetComponent<CargoDrone>();
                    break;
                case "relay1":
                    go = Instantiate(relayPref, position, Quaternion.identity);
                    pool.Add(name, go);
                    script = go.GetComponent<Relay>();
                    break;
                case "repairStation1":
                    go = Instantiate(repairStationPref, position, Quaternion.identity);
                    pool.Add(name, go);
                    script = go.GetComponent<RepairStation>();
                    break;
                case "repairDrone1":
                    go = Instantiate(repairDromePref, position, Quaternion.identity);
                    pool.Add(name, go);
                    script = go.GetComponent<RepairDrone>();
                    break;
                case "miner1":
                    go = Instantiate(minerPref, position, Quaternion.identity);
                    pool.Add(name, go);
                    script = go.GetComponent<Miner>();
                    break;
                case "asteroid1":
                    go = Instantiate(asteroid1Pref, position, Quaternion.identity);
                    pool.Add(name, go);
                    script = go.GetComponent<Asteroid>();
                    break;
                case "asteroid2":
                    go = Instantiate(asteroid2Pref, position, Quaternion.identity);
                    pool.Add(name, go);
                    script = go.GetComponent<Asteroid>();
                    break;
                case "asteroid3":
                    go = Instantiate(asteroid3Pref, position, Quaternion.identity);
                    pool.Add(name, go);
                    script = go.GetComponent<Asteroid>();
                    break;
                case "asteroid4":
                    go = Instantiate(asteroid4Pref, position, Quaternion.identity);
                    pool.Add(name, go);
                    script = go.GetComponent<Asteroid>();
                    break;
                case "asteroid5":
                    go = Instantiate(asteroid5Pref, position, Quaternion.identity);
                    pool.Add(name, go);
                    script = go.GetComponent<Asteroid>();
                    break;
                case "laser1":
                    go = Instantiate(laserPref, position, Quaternion.identity);
                    pool.Add(name, go);
                    script = go.GetComponent<Laser>();
                    break;
                case "missileLauncher1":
                    go = Instantiate(missileLauncherPref, position, Quaternion.identity);
                    pool.Add(name, go);
                    script = go.GetComponent<MissileLauncher>();
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


    //Object energy connection methods
    public void findConnections(GameObject newGameObject)
    {
        // bool isInConnection = false;
        // bool isOutConnecton = false;
        // bool isConnected = false;

        Structure newStructure = newGameObject.GetComponent<Structure>();

        foreach (GameObject poolGameObject in Pool.Values)
        {
            Structure poolStructure = poolGameObject.GetComponent<Structure>();

            if (newGameObject.name != poolGameObject.name)
            {
                //to use when the requester object is an energy station.
                if (newStructure.Data.identifier == GameObjectType.SolarStation)
                {
                    if (poolStructure.Data.identifier == GameObjectType.EnergyStorage)
                    {
                        newStructure.addStorageStructure(poolGameObject);
                    }

                    foreach (GameObjectType identifier in newStructure.Data.outs)
                    {
                        if (identifier == poolStructure.Data.identifier)
                        {
                            if (isWithinRange(newGameObject.transform.position, poolGameObject.transform.position, poolStructure.Data.range))
                            {
                                Debug.DrawLine(poolGameObject.transform.position, newGameObject.transform.position, Color.cyan);
                                newStructure.IsConnected = true;
                                poolStructure.addEnergySource(newGameObject);
                            }
                            else
                            {
                                newStructure.IsConnected = false;
                                poolStructure.removeEnergySource(newGameObject);
                            }
                        }
                    }
                }
                else
                {
                    foreach (GameObjectType identifier in newStructure.Data.ins)
                    {
                        if (identifier == poolStructure.Data.identifier)
                        {

                            //Add material storage to Stronghold
                            if (newStructure.Data.identifier == GameObjectType.MineralStorage &&
                                poolStructure.Data.identifier == GameObjectType.Stronghold)
                            {
                                if (isWithinRange(newGameObject.transform.position, poolGameObject.transform.position, poolStructure.Data.range))
                                {
                                    newStructure.IsConnected = true;
                                    Debug.DrawLine(poolGameObject.transform.position, newGameObject.transform.position, Color.red);
                                    poolStructure.addStorageStructure(newGameObject);
                                    break;
                                }
                                else
                                {
                                    newStructure.IsConnected = false;
                                    poolStructure.removeStorageStructure(newGameObject);
                                    break;
                                }
                            }

                            //Add asteroids to Miner
                            if (newStructure.Data.identifier == GameObjectType.Miner &&
                                poolStructure.Data.identifier == GameObjectType.Asteroid)
                            {
                                if (isWithinRange(newGameObject.transform.position, poolGameObject.transform.position, newStructure.Data.range))
                                {
                                    Debug.DrawLine(poolGameObject.transform.position, newGameObject.transform.position, Color.white);
                                    newStructure.addMineralSource(poolGameObject);
                                }
                                else
                                {
                                    newStructure.removeMineralSource(poolGameObject);

                                }
                            }

                            //Add EnegyStorage to SolarStation
                            if (newStructure.Data.identifier == GameObjectType.EnergyStorage &&
                                poolStructure.Data.identifier == GameObjectType.SolarStation)
                            {
                                if (isWithinRange(newGameObject.transform.position, poolGameObject.transform.position, poolStructure.Data.range))
                                {
                                    Debug.DrawLine(poolGameObject.transform.position, newGameObject.transform.position, Color.yellow);
                                    poolStructure.addStorageStructure(newGameObject);
                                }
                                else
                                {
                                    poolStructure.removeStorageStructure(newGameObject);
                                }
                            }


                            //Add relay connections
                            if (newStructure.Data.identifier == GameObjectType.Relay || poolStructure.Data.identifier == GameObjectType.Relay || poolStructure.Data.identifier == GameObjectType.SolarStation)
                            {
                                if (isWithinRange(newGameObject.transform.position, poolGameObject.transform.position, poolStructure.Data.range))
                                {
                                    Debug.DrawLine(poolGameObject.transform.position, newGameObject.transform.position, Color.yellow);
                                    newStructure.addEnergySource(poolGameObject);
                                }
                                else
                                {
                                    newStructure.removeEnergySource(poolGameObject);
                                }
                            }

                            // if (isWithinRange(newGameObject.transform.position, poolGameObject.transform.position, poolStructure.Data.range))
                            // {
                            // //Add EnegyStorage to SolarStation
                            // if (newStructure.Data.identifier == GameObjectType.EnergyStorage &&
                            //     poolStructure.Data.identifier == GameObjectType.SolarStation)
                            // {
                            //     Debug.DrawLine(poolGameObject.transform.position, newGameObject.transform.position, Color.yellow);
                            //     poolStructure.addStorageStructure(newGameObject);
                            // }
                            // else
                            // {
                            //Add any other relationship
                            // Debug.DrawLine(poolGameObject.transform.position, newGameObject.transform.position, Color.cyan);
                            // newStructure.addEnergySource(poolGameObject);
                            // }

                            // }
                            // else
                            // {
                            // newStructure.removeEnergySource(poolGameObject);
                            // }
                        }
                    }
                }

            }
        }
    }

    private bool isWithinRange(Vector3 toPosition, Vector3 fromPosition, int range)
    {
        float newRange = range / 2;
        float result = Vector2.Distance(new Vector2(toPosition.x, toPosition.y), new Vector2(fromPosition.x, fromPosition.y));
        result -= 1.28f;//reduce some distance to compensate the size of the object.
        if (result <= newRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool removeCircularConnections(Structure pool, string requester)
    {
        return true;
    }

    //Level data methods
    public void saveLevelData()
    {
        List<AsteroidLevelData> asteroidsList = new List<AsteroidLevelData>();
        foreach (GameObject item in pool.Values)
        {
            GameObjectData objectData = item.GetComponent<Structure>().Data;
            if (objectData.identifier == GameObjectType.Asteroid)
            {
                asteroidsList.Add(new AsteroidLevelData(objectData.name, item.transform.position));
            }
        }

        this.dataManager.addAsteroidsToLevel(asteroidsList);
        this.dataManager.saveGameLevelsData();
    }

    private void createLevelObjects()
    {
        GameLevelData levelData = this.dataManager.GameLevelsData[this.dataManager.CurrenLevel];
        foreach (AsteroidLevelData item in levelData.asteroids)
        {
            createObject(item.name, item.position, false);
        }
    }


    public bool requestDrone(GameObject target)
    {
        return this.stronghold.GetComponent<Stronghold>().sendDrome(target);
    }
}
