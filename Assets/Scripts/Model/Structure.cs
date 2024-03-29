﻿using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    //Prefabs declarations
    public GameObject structureRangePref;

    //Instance Variables
    //To control the order of the connections.
    protected static int connectionCounter = 1;
    protected int connectionIndex = 1;

    //Flag to know if structre was succesfully connected to some other structure to be able to place it.
    protected bool isConnected = false;

    protected GameManager gameManager;
    protected GameObjectData data;
    protected Dictionary<string, GameObject> energySources = new Dictionary<string, GameObject>();
    protected Dictionary<string, GameObject> storageStructures = new Dictionary<string, GameObject>();
    protected Dictionary<string, GameObject> mineralSources = new Dictionary<string, GameObject>();
    protected Dictionary<string, GameObject> dromes = new Dictionary<string, GameObject>();

    protected bool isRequestingEnergy = false;
    public bool isOn = false;
    protected bool isAlwaysDragable = false;

    protected GameObject range;
    protected bool isPlaced = false;
    protected float counter = 0.0f;
    protected int dromesAddedCounter = 0;

    //Properties
    public int ConnectionCounter { get { return connectionCounter++; } }
    public int ConnectionIndex { get { return connectionIndex; } set { this.connectionIndex = value; } }
    public bool IsConnected { get { return this.isConnected; } set { this.isConnected = value; } }
    public GameManager GameManager { get { return this.gameManager; } set { this.gameManager = value; } }
    public GameObjectData Data { set { this.data = value; } get { return this.data; } }
    public Dictionary<string, GameObject> EnergySources { get { return this.energySources; } set { this.energySources = value; } }
    public Dictionary<string, GameObject> StorageStructures { get { return this.storageStructures; } set { this.storageStructures = value; } }
    public Dictionary<string, GameObject> MineralSources { get { return this.mineralSources; } set { this.mineralSources = value; } }
    public Dictionary<string, GameObject> Dromes { get { return this.dromes; } set { this.dromes = value; } }
    public bool IsRequestingEnergy { get { return this.isRequestingEnergy; } set { this.isRequestingEnergy = value; } }
    public bool IsOn { get { return this.isOn; } set { this.isOn = value; } }
    public bool IsAlwaysDragable { get { return this.isAlwaysDragable; } set { this.isAlwaysDragable = value; } }
    public bool IsPlaced { get { return this.isPlaced; } set { this.isPlaced = value; } }

    //For debugging
    public bool isShowEnergysourceTree = false;

    void OnMouseUp()
    {
        gameManager.disableCameraMove = false;

        if (!isPlaced)
        {
            isPlaced = true;
            turnOn();
        }


    }

    void OnMouseDown()
    {
        this.gameManager.disableCameraMove = true;
        this.gameManager.setCurrentObjectToDisplay(this);
    }

    void OnMouseDrag()
    {
        if (!isPlaced || isAlwaysDragable)
        {
            Vector3 point = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            point.z = gameObject.transform.position.z;
            gameObject.transform.position = point;
            if (range)
            {
                range.transform.position = point;
            }
            this.gameManager.findConnections(gameObject);
        }
    }

    void OnMouseOver()
    {
        if (!isShowEnergysourceTree && isPlaced && data.identifier != GameObjectType.Asteroid)
        {
            showEnergySourceTree();
        }
    }

    void OnMouseExit()
    {
        if (isShowEnergysourceTree && isPlaced && data.identifier != GameObjectType.Asteroid)
        {
            hideEnergySourceTree();
        }
    }


    //Instance methods
    //Add the gameobject range to the structure.
    public void addRangeGameObject()
    {
        this.range = Instantiate(structureRangePref, transform.position, Quaternion.identity);
        this.range.transform.localScale += new Vector3(this.data.range, this.data.range, 0);
        this.range.transform.parent = gameObject.transform;
    }

    //Method call when the structre uses energy.
    public void useEnergy()
    {
        //1. request energy from source.

    }

    public void removeHigherConnections()
    {
        int previousConnection = this.connectionIndex;
        GameObject previousGO = null;

        foreach (GameObject item in energySources.Values)
        {
            if (item.GetComponent<Structure>().ConnectionIndex < previousConnection)
            {
                previousConnection = item.GetComponent<Structure>().ConnectionIndex;
                previousGO = item;
            }
        }

        if (previousGO != null)
        {
            energySources.Clear();
            energySources.Add(previousGO.name, previousGO);
        }

    }

    public void addEnergySource(GameObject energySource)
    {
        if (energySource.name != gameObject.name)
        {
            if (!energySources.ContainsKey(energySource.name))
            {
                energySources.Add(energySource.name, energySource);
            }
        }
    }

    public void removeEnergySource(GameObject energySource)
    {
        if (energySources.ContainsKey(energySource.name))
        {
            energySources.Remove(energySource.name);
        }
    }

    //Request energy from its energy source.
    //It will return the ammount of enegy available if any.
    public int requestEnergy(int requestedEnergy)
    {
        if (data.identifier == GameObjectType.SolarStation)
        {
            //Debug.Log("calling sendEnergy on energy station");
            return sendEnergy(requestedEnergy);
        }
        else
        {
            foreach (GameObject item in energySources.Values)
            {
                //Debug.Log(("requesting energy from:" + item.name));
                int energy = item.GetComponent<Structure>().requestEnergy(requestedEnergy);

                //Debug.Log(("energy: " + energy));
                //Debug.Log(("energyUsage: " + Data.energyRequire));

                if (energy > 0)
                {
                    //Debug.Log(("returning energy from:" + item.name + " energy: " + energy));
                    return energy;
                }
            }
        }
        return 0;
    }

    public virtual int sendEnergy(int requestedEnergy)
    {
        return 0;
    }

    public virtual void turnOn()
    {
    }

    public virtual void turnOff()
    {
    }

    public virtual void work()
    {
    }

    public virtual void workComplete()
    {
    }

    public virtual void addStorageStructure(GameObject value)
    {
    }

    public virtual void removeStorageStructure(GameObject value)
    {
    }

    public virtual void addMineralSource(GameObject value)
    {
        if (value.name != gameObject.name)
        {
            if (!mineralSources.ContainsKey(value.name))
            {
                mineralSources.Add(value.name, value);

            }
        }
    }

    public virtual void removeMineralSource(GameObject value)
    {
        if (mineralSources.ContainsKey(value.name))
        {
            mineralSources.Remove(value.name);
        }
    }

    public virtual bool saveProduction(int value)
    {
        return false;
    }

    public virtual bool useProduction(int value)
    {
        return false;
    }

    //Temporal methods to show energy tree
    public void showEnergySourceTree()
    {

        isShowEnergysourceTree = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;

        if (data.identifier == GameObjectType.SolarStation || energySources.Count == 0)
        {
            return;
        }

        if (isShowEnergysourceTree)
        {
            foreach (GameObject item in energySources.Values)
            {
                item.GetComponent<Structure>().showEnergySourceTree();
            }
        }
    }

    public void hideEnergySourceTree()
    {

        isShowEnergysourceTree = false;
        if (isOn)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        }

        if (data.identifier == GameObjectType.SolarStation || energySources.Count == 0)
        {
            return;
        }

        if (!isShowEnergysourceTree)
        {
            foreach (GameObject item in energySources.Values)
            {
                item.GetComponent<Structure>().hideEnergySourceTree();
            }
        }
    }

    public bool isLowerConnection(int index)
    {
        //int previousIndex = this.connectionIndex;
        foreach (GameObject energySource in energySources.Values)
        {


            if (index < energySource.GetComponent<Structure>().ConnectionIndex)
            {
                return true;
            }
            else
            {
                return false;
            }

            // if (energySource.GetComponent<Structure>().EnergySources.ContainsKey(key))
            // {
            //     EnergySources.Remove(key);
            //     Debug.Log(("this " + gameObject.name + "contains key: " + key));
            //     return true;
            // }
            // else if (energySource.GetComponent<Structure>().removeCircularConnections(energySource.name))
            // {
            //     Debug.Log(("this " + gameObject.name + ", energy source: " + energySource.name + ", contains key: " + key));
            //     return true;
            // }

            // Debug.Log(("this " + gameObject.name + " NOT contains key: " + key));
        }
        return true;
    }
}
