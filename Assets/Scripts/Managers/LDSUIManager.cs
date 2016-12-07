using UnityEngine;

public class LDSUIManager : MonoBehaviour {
    
    private LDSGameManager gameManager;

    private float screenHeight = Screen.height;
    private float ypos;
    private float xpos;
    private float buttonHeight = 50.0f;
    private float buttonWidth;
    
    private GUIStyle style;

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
        //Debug.Log(screenWidth);
        //Debug.Log(screenHeight);
        buttonWidth = 60.0f;
        style = new GUIStyle();
        style.fontSize = 20;
        style.normal.textColor = Color.white;
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
        
        
        xpos = 10;
        ypos = (screenHeight - ( buttonHeight + 10));

        if (GUI.Button(new Rect(xpos, ypos, buttonWidth, buttonHeight), "Solar")) {
        gameManager.addSolarStation();
        }

        xpos += (buttonWidth + 10);
        if (GUI.Button(new Rect(xpos, ypos, buttonWidth, buttonHeight), "Battery")) {
        gameManager.addBattery();
        }
        xpos += (buttonWidth + 10);
        if (GUI.Button(new Rect(xpos, ypos, buttonWidth, buttonHeight), "Relay")) {
            gameManager.addRelay();
        }

        xpos += (buttonWidth + 10);
        if(GUI.Button(new Rect(xpos, ypos, buttonWidth, buttonHeight),"Repair")) {
            gameManager.addRepairStation();
        }
        xpos += (buttonWidth + 10);
        if (GUI.Button(new Rect(xpos, ypos, buttonWidth, buttonHeight), "Miner")) {
            gameManager.addMiner();
        }

        xpos = 10;
        ypos = 10;
    
        GUI.Label(new Rect(xpos, ypos, 100, 50), string.Concat("Cash:", gameManager.player.Cash), style);
        
    }
}   