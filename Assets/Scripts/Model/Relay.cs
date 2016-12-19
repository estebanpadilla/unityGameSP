using UnityEngine;

public class Relay : Structure
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

}