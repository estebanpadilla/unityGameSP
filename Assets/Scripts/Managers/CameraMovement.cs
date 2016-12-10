using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 resetCamera;
    private Vector3 origin;
    private Vector3 diference;
    private bool drag = false;

    private GameManager gameManager;

    void Start()
    {
        resetCamera = Camera.main.transform.position;
        gameManager = GameObject.FindWithTag("gameManager").GetComponent<GameManager>();
    }
    void LateUpdate()
    {
        if (gameManager.disableCameraMove)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            diference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if (drag == false)
            {
                drag = true;
                origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }
        if (drag == true)
        {
            Camera.main.transform.position = origin - diference;
        }
        //RESET CAMERA TO STARTING POSITION WITH RIGHT CLICK
        if (Input.GetMouseButton(1))
        {
            Camera.main.transform.position = resetCamera;
        }
    }

}