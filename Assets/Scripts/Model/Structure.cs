using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    //Prefabs declarations
    public GameObject structureRangePref;

    //Instance Variables
    protected GameManager gameManager;
    protected GameObjectData data;
    protected Dictionary<string, GameObject> energySources = new Dictionary<string, GameObject>();
    protected bool isRequestingEnergy = false;
    public bool isWorking = false;
    protected bool isAlwaysDragable = false;

    protected GameObject range;
    private bool isPlaced = false;
    protected float counter = 0.0f;

    //Properties
    public GameManager GameManager { get { return this.gameManager; } set { this.gameManager = value; } }
    public GameObjectData Data { set { this.data = value; } get { return this.data; } }
    public Dictionary<string, GameObject> EnergySources { get { return this.energySources; } set { this.energySources = value; } }
    public bool IsRequestingEnergy { get { return this.isRequestingEnergy; } set { this.isRequestingEnergy = value; } }
    public bool IsWorking { get { return this.isWorking; } set { this.isWorking = value; } }
    public bool IsAlwaysDragable { get { return this.isAlwaysDragable; } set { this.isAlwaysDragable = value; } }

    //For debugging
    public bool isShowEnergysourceTree = false;

    void OnMouseUp()
    {
        gameManager.disableCameraMove = false;

        if (!isPlaced)
        {
            isPlaced = true;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
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
        if (!isShowEnergysourceTree && isPlaced && data.identifier != 8)
        {
            showEnergySourceTree();
        }
    }

    void OnMouseExit()
    {
        if (isShowEnergysourceTree && isPlaced && data.identifier != 8)
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

    public int requestEnergy(int requestedEnergy)
    {
        if (data.identifier == 2)
        {
            return sendEnergy(requestedEnergy);
        }
        else if (energySources.Count == 0)
        {
            return -1;
        }
        else
        {
            foreach (GameObject item in energySources.Values)
            {
                Debug.Log(("requesting energy from:" + item.name));
                return item.GetComponent<Structure>().requestEnergy(requestedEnergy);
            }
        }

        return 0;
    }

    public virtual int sendEnergy(int requestedEnergy)
    {
        return 0;
    }

    //Temporal methods to show energy tree
    public void showEnergySourceTree()
    {

        isShowEnergysourceTree = true;
        Debug.Log(gameObject.name);
        Debug.Log("showing EnergySourceTree");
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;

        if (data.identifier == 2 || energySources.Count == 0)
        {
            Debug.Log("exit");
            return;
        }

        if (isShowEnergysourceTree)
        {
            Debug.Log("showing EnergySourceTree");
            Debug.Log(energySources.Count);

            foreach (GameObject item in energySources.Values)
            {
                item.GetComponent<Structure>().showEnergySourceTree();
            }
        }
    }

    public void hideEnergySourceTree()
    {

        isShowEnergysourceTree = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        if (data.identifier == 2 || energySources.Count == 0)
        {
            Debug.Log("exit");
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
}
