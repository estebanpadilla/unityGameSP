using UnityEngine;
using System.Collections.Generic;
class Stronghold : Structure
{

    public List<GameObject> minersQueue = new List<GameObject>();
    private bool isStorageAvailable = true;

    void Start()
    {
        addRangeGameObject();
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    public override void turnOn()
    {
        //Debug.Log(("turnOn: " + gameObject.name));
        this.isOn = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        if (this.dromesAddedCounter < this.Data.dronesCty)
        {
            addMaterialDromes();
            addMaterialDromes();
            addMaterialDromes();
            addMaterialDromes();
        }
    }

    public override void turnOff()
    {
        this.isOn = false;
        CancelInvoke();
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    private void addMaterialDromes()
    {
        if (this.dromesAddedCounter < this.Data.dronesCty)
        {
            this.dromesAddedCounter++;
            Vector3 position = Vector3.zero;
            float angle = 0;
            switch (this.dromesAddedCounter)
            {
                case 1:
                    position = new Vector3(this.transform.position.x, (this.transform.position.y + 1), 0.0f);
                    angle = 0;
                    break;
                case 2:
                    position = new Vector3((this.transform.position.x - 1.0f), this.transform.position.y, 0.0f);
                    angle = 90.0f;
                    break;
                case 3:
                    position = new Vector3(this.transform.position.x, (this.transform.position.y - 1), 0.0f);
                    angle = 180.0f;
                    break;
                case 4:
                    position = new Vector3((this.transform.position.x + 1.0f), this.transform.position.y, 0.0f);
                    angle = 270.0f;
                    break;
                default:
                    break;
            }

            string dromeName = string.Concat("cargoDrone1_", this.gameManager.ObjectCounter);
            GameObject go = Instantiate(this.gameManager.cargoDronePref, position, Quaternion.AngleAxis(angle, Vector3.forward));
            go.name = dromeName;
            go.GetComponent<CargoDrone>().Data = this.gameManager.DataManager.findGameObjectData("cargoDrone1").Clone();
            go.GetComponent<CargoDrone>().GameManager = this.gameManager;
            go.GetComponent<CargoDrone>().Stronghold = this;
            gameManager.Pool.Add(dromeName, go);
            this.dromes.Add(dromeName, go);
            this.gameManager.ObjectCounter++;
        }
    }

    public bool sendDrome(GameObject target)
    {
        if (isStorageAvailable)
        {
            if (!checkMinerName(target.name))
            {
                Debug.Log(("send drone to " + target.name));
                minersQueue.Add(target);
                work();
                //this.dromes["materialDrone1_59"].GetComponent<MaterialDrone>().moveTo(target);
                return true;
            }
            else
            {
                return false;
            }
        }

        Debug.Log("Not able to send drone, not storage available.");
        return false;
    }

    private bool checkMinerName(string name)
    {
        for (int i = 0; i < minersQueue.Count; i++)
        {
            if (minersQueue[i].name.Equals(name))
            {
                return true;
            }
        }
        return false;
    }

    public override void work()
    {
        Debug.Log("work Stronghold");
        if (minersQueue.Count > 0)
        {

            for (int i = minersQueue.Count; i > 0; i--)
            {
                Miner miner = minersQueue[(i - 1)].GetComponent<Miner>();
                if (!miner.IsDroneSent)
                {
                    foreach (GameObject droneGO in this.dromes.Values)
                    {
                        CargoDrone drome = droneGO.GetComponent<CargoDrone>();
                        if (!drome.isOn)
                        {
                            Debug.Log(("SENDING DRONE TO: " + minersQueue[(i - 1)].name));
                            miner.IsDroneSent = true;
                            droneGO.GetComponent<CargoDrone>().moveTo(minersQueue[(i - 1)]);
                            minersQueue.RemoveAt((i - 1));
                            return;
                        }
                    }
                }
            }
        }
        else
        {
            Debug.Log("NO MINERS WAITING!");
        }
    }

    public void returnedToBase(CargoDrone drome)
    {
        bool materialSaved = false;
        float cargo = drome.unloadCargo();

        if ((this.data.productionQty + cargo) < this.data.storageCty)
        {
            materialSaved = true;
            this.data.productionQty += cargo;
        }
        else
        {
            if (this.storageStructures.Count > 0)
            {
                foreach (GameObject storageGO in this.storageStructures.Values)
                {
                    MaterialStorage materialStorage = storageGO.GetComponent<MaterialStorage>();
                    if ((materialStorage.Data.productionQty + cargo) < materialStorage.Data.storageCty)
                    {
                        materialSaved = true;
                        materialStorage.Data.productionQty += cargo;
                        break;
                    }
                }
            }
            else
            {
                Debug.Log("There is not material storage units available.");
            }
        }

        if (!materialSaved)
        {
            isStorageAvailable = false;
            Debug.Log("Stop sending dromes.");
        }

        //if (checkMinerName(drome.Target.name))
        //{
        //minersQueue.Remove(drome.Target);
        //drome.Target = null;
        //drome.IsOn = false;
        work();
        //}
    }

    public override void addStorageStructure(GameObject value)
    {
        if (value.name != gameObject.name)
        {
            if (!this.storageStructures.ContainsKey(value.name))
            {
                isStorageAvailable = true;
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

}