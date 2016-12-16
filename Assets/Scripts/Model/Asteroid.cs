using UnityEngine;
public class Asteroid : Structure
{

    /// <summary>
    /// OnMouseUpAsButton is only called when the mouse is released over
    /// the same GUIElement or Collider as it was pressed.
    /// </summary>
    void OnMouseUpAsButton()
    {
        //this.gameManager.requestDrone(this.gameObject);
    }


    void Start()
    {
        isAlwaysDragable = true;
    }

    public override bool useProduction(int value)
    {
        if (this.Data.productionQty >= value)
        {
            this.Data.productionQty -= value;
            return true;
        }

        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        return false;
    }
}
