using UnityEngine;
class MineralStorage : Structure
{
    void Start()
    {
        addRangeGameObject();
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    public override void turnOn()
    {
        if (this.isConnected)
        {
            this.isOn = true;
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