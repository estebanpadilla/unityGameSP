using UnityEngine;

public class Relay : Structure
{

    void Start()
    {
        this.connectionIndex = ConnectionCounter;
        Debug.Log(("ConnectionIndex " + this.connectionIndex));
        addRangeGameObject();
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    public override void turnOn()
    {
        this.isOn = true;
        removeHigherConnections();
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public override void turnOff()
    {
        this.isOn = false;
        CancelInvoke();
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

}