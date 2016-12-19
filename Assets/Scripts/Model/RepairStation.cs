using UnityEngine;
class RepairStation : Structure
{

    void Start()
    {
        this.connectionIndex = ConnectionCounter;
        addRangeGameObject();
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    public override void turnOn()
    {

        if (this.energySources.Count > 0)
        {
            this.isOn = true;
            removeHigherConnections();
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            if (this.dromesAddedCounter < this.Data.dronesCty)
            {
                addRepairDromes();
                addRepairDromes();
                addRepairDromes();
                addRepairDromes();
            }
        }
        else
        {
            this.isPlaced = false;
        }
    }

    public override void turnOff()
    {
        this.isOn = false;
        CancelInvoke();
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    private void addRepairDromes()
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

            string dromeName = string.Concat("repairDrone1_", this.gameManager.ObjectCounter);
            GameObject go = Instantiate(this.gameManager.repairDromePref, position, Quaternion.AngleAxis(angle, Vector3.forward));
            go.name = dromeName;
            go.GetComponent<RepairDrone>().Data = this.gameManager.DataManager.findGameObjectData("repairDrone1").Clone();
            go.GetComponent<RepairDrone>().GameManager = this.gameManager;
            //go.GetComponent<CargoDrone>().Stronghold = this;
            gameManager.Pool.Add(dromeName, go);
            this.dromes.Add(dromeName, go);
            this.gameManager.ObjectCounter++;
        }
    }

}