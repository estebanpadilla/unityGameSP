using UnityEngine;
class Miner : Structure
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
        Debug.Log("request energy");
        int energy = this.requestEnergey(Data.energyUsage);
        Debug.Log(energy);
    }
}