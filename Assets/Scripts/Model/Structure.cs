using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{

    public GameObject structureRange;

    //Instance Variables
    protected LDSGameManager gameManager;
    public LDSGameManager GameManager { get { return this.gameManager; } set { this.gameManager = value; } }

    protected LDSData data;
    public LDSData Data { set { this.data = value; } get { return this.data; } }

    protected List<string> upGradeKeys;
    protected GameObject range;
    protected bool isPlaced = false;

    //Connection objects
    protected GameObject[] ins;
    public GameObject[] Ins { get { return this.ins; } set { this.ins = value; } }
    protected GameObject[] outs;
    public GameObject[] Outs { get { return this.outs; } set { this.outs = value; } }

    void OnMouseUp()
    {
        if (!isPlaced)
        {
            isPlaced = true;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseDown()
    {
        this.gameManager.setCurrentObjectToDisplay(this);
    }

    void OnMouseDrag()
    {
        if (!isPlaced)
        {
            Vector3 point = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            point.z = gameObject.transform.position.z;
            gameObject.transform.position = point;
            range.transform.position = point;
            gameManager.findConnections(gameObject);
        }
    }
}
