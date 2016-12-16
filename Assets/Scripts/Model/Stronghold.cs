using UnityEngine;
class Stronghold : Structure
{

    void Start()
    {
        addRangeGameObject();
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    /// <summary>
    /// OnMouseUpAsButton is only called when the mouse is released over
    /// the same GUIElement or Collider as it was pressed.
    /// </summary>
    void OnMouseUpAsButton()
    {
        Debug.Log("click on Stronghold");
        this.addMaterialDromes();
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
        //Debug.Log(("turnOff: " + gameObject.name));
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
            switch (this.dromesAddedCounter)
            {
                case 1:
                    position = new Vector3((this.transform.position.x - 1.0f), this.transform.position.y, 0.0f);
                    break;
                case 2:
                    position = new Vector3(this.transform.position.x, (this.transform.position.y + 1), 0.0f);
                    break;
                case 3:
                    position = new Vector3((this.transform.position.x + 1.0f), this.transform.position.y, 0.0f);
                    break;
                case 4:
                    position = new Vector3(this.transform.position.x, (this.transform.position.y - 1), 0.0f);
                    break;
                default:
                    break;
            }

            this.gameManager.addMaterialDroneWithPosition(position);
        }
    }
}