using UnityEngine;

public class LDSUIManager : MonoBehaviour {
    
    private LDSGameManager gameManager;

    private float screenWidth = Screen.width;
    private float screenHeight = Screen.height;
    private float ypos;
    private float xpos;
    private float buttonHeight = 50.0f;
    private float buttonWidth;
    
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake() {
        gameManager = GameObject.FindGameObjectWithTag("gameManager").GetComponent<LDSGameManager>();
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() {
        Debug.Log(screenWidth);
        Debug.Log(screenHeight);
        ypos = (screenHeight - ( buttonHeight + 10));
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        
    }

    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// This function can be called multiple times per frame (one call per event).
    /// </summary>
    void OnGUI() {
        
        buttonWidth = 60.0f;
        xpos = 10;
         if (GUI.Button(new Rect(xpos, ypos, buttonWidth, buttonHeight), "Solar")) {
            Debug.Log("Clicked the button with an image");
         }

         xpos += (buttonWidth + 10);
         if (GUI.Button(new Rect(xpos, ypos, buttonWidth, buttonHeight), "Battery")) {
            Debug.Log("Clicked the button with an image");
         }
         xpos += (buttonWidth + 10);
         if (GUI.Button(new Rect(xpos, ypos, buttonWidth, buttonHeight), "Relay")) {

         }

         xpos += (buttonWidth + 10);
         if(GUI.Button(new Rect(xpos, ypos, buttonWidth, buttonHeight),"Repair")) {

         }
         xpos += (buttonWidth + 10);
         if (GUI.Button(new Rect(xpos, ypos, buttonWidth, buttonHeight), "Miner")) {
             gameManager.addMiner();
         }

    }
}   