using UnityEngine;
class Stronghold : Structure
{

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
    }

    public override void turnOff()
    {
        //Debug.Log(("turnOff: " + gameObject.name));
        this.isOn = false;
        CancelInvoke();
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

}