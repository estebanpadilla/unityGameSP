using UnityEngine;
class MaterialStorage : Structure
{
    void Start()
    {
        addRangeGameObject();
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    public override void turnOn()
    {
        this.isOn = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public override void turnOff()
    {
        this.isOn = false;
        CancelInvoke();
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }
}