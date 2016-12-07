using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour {

	public GameObject structureRange;
    
	//Instance Variables
	protected LDSData data;
	public LDSData Data { set { this.data = value; } get { return this.data; } }

	protected List<string> upGradeKeys;
	protected GameObject range;
    protected bool isPlaced = false;
	
    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseDown() {
		        
    }

    /// <summary>
    /// OnMouseUp is called when the user has released the mouse button.
    /// </summary>
    void OnMouseUp() {
        if ( !isPlaced ) {
            isPlaced = true;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            range.transform.parent = gameObject.transform;
        }
    }

    /// <summary>
    /// OnMouseDrag is called when the user has clicked on a GUIElement or Collider
    /// and is still holding down the mouse.
    /// </summary>
    void OnMouseDrag() {
        if ( !isPlaced ) { 
            Vector3 point = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            point.z = gameObject.transform.position.z;
            gameObject.transform.position = point;
            range.transform.position = point;
        }
    }
}
