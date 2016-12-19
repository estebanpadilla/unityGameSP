using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningAnimation : MonoBehaviour
{

    public GameObject box;

    private float step = 0.5f;
    private float stepRotation = 15.0f;
    private Vector3 destination = new Vector3(3, 3, 0);
    private bool move = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 screenPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(pos);
            //transform.Rotate(new Vector3(0, 0, 90.0f));
            Debug.Log(("Screen position" + screenPos));
            // Gets a vector that points from the player's position to the target's.
            Vector3 pos = (new Vector3(screenPos.x, screenPos.y, 0)) - transform.position;
            Debug.Log(("Distance: " + pos));
            float magnitude = pos.magnitude;
            Debug.Log(("Magnitude or distance: " + magnitude));
            float sqrtMagnitude = pos.sqrMagnitude;
            Debug.Log(("Sqrt Magnitude: " + magnitude));
            Vector3 direction = pos / magnitude;
            Debug.Log(("Direcction: " + direction));
            Vector3 perp = Vector3.Cross(transform.position, new Vector3(screenPos.x, screenPos.y, 0));
            Debug.Log(("Perp: " + perp));

        }



        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = Vector3.Lerp(transform.position, destination, (step * Time.deltaTime));
            //transform.Translate(destination * step * Time.deltaTime);
            //Debug.Log(Vector3.Dot(destination, transform.position));
            //transform.LookAt(transform.position + (new Vector3(0, 0, 1)), destination);


            // Vector3 vectorToTarget = destination - transform.position;
            // float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            // Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            // transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * step);

            // if (Input.GetMouseButtonDown(1))
            // {
            //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //     if (Physics.Raycast(ray))
            //         Instantiate(box, transform.position, transform.rotation);
            // }



            // if (Vector3.Dot(destination, transform.position) > 0)
            // {
            //     transform.Rotate(Vector3.forward, stepRotation * Time.deltaTime);
            // }
            // else
            // {
            //     transform.Rotate(-Vector3.forward, stepRotation * Time.deltaTime);
            // }

        }

    }

    /// <summary>
    /// OnMouseUpAsButton is only called when the mouse is released over
    /// the same GUIElement or Collider as it was pressed.
    /// </summary>
    void OnMouseUpAsButton()
    {
        move = !move;
    }
}
