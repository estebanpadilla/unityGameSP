using UnityEngine;

public class LDSUIManager : MonoBehaviour
{

    public Texture2D buttonTexture;

    private LDSGameManager gameManager;
    private Structure currentObject;
    public Structure CurrentObject { get { return this.currentObject; } set { this.currentObject = value; } }

    private float screenHeight = Screen.height;
    private float ypos;
    private float xpos;
    private float buttonHeight;
    private float buttonWidth;

    private GUIStyle style;
    private GUIStyle buttonStyle;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("gameManager").GetComponent<LDSGameManager>();
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        //Debug.Log(screenWidth);
        //Debug.Log(screenHeight);
        buttonWidth = 100.0f;
        buttonHeight = 50.0f;
        style = new GUIStyle();
        style.fontSize = 20;
        style.normal.textColor = Color.white;

        buttonStyle = new GUIStyle();
        buttonStyle.fontSize = 20;
        buttonStyle.normal.textColor = Color.black;
        buttonStyle.normal.background = buttonTexture;
        buttonStyle.alignment = TextAnchor.MiddleCenter;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {

    }

    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// This function can be called multiple times per frame (one call per event).
    /// </summary>
    void OnGUI()
    {

        xpos = 10;
        ypos = (screenHeight - (buttonHeight + 10));
        if (GUI.Button(new Rect(xpos, ypos, buttonWidth, buttonHeight), "Solar", buttonStyle))
        {
            gameManager.addSolarStation();
        }

        xpos += (buttonWidth + 10);
        if (GUI.Button(new Rect(xpos, ypos, buttonWidth, buttonHeight), "Enegy \nStorage", buttonStyle))
        {
            gameManager.addEnegyStorage();
        }

        xpos += (buttonWidth + 10);
        if (GUI.Button(new Rect(xpos, ypos, buttonWidth, buttonHeight), "Relay", buttonStyle))
        {
            gameManager.addRelay();
        }

        xpos += (buttonWidth + 10);
        if (GUI.Button(new Rect(xpos, ypos, buttonWidth, buttonHeight), "Repair", buttonStyle))
        {
            gameManager.addRepairStation();
        }

        xpos += (buttonWidth + 10);
        if (GUI.Button(new Rect(xpos, ypos, buttonWidth, buttonHeight), "Miner", buttonStyle))
        {
            gameManager.addMiner();
        }

        xpos = 10;
        ypos = 10;
        GUI.Label(new Rect(xpos, ypos, 100, 50), string.Concat("Cash:", gameManager.player.Cash), style);

        if (currentObject != null)
        {
            ypos += 40;
            GUI.Label(new Rect(xpos, ypos, 200, 20), "Current Structure", style);
            ypos += 25;
            GUI.Label(new Rect(xpos, ypos, 200, 20), string.Concat("Type: ", this.currentObject.Data.name), style);
            ypos += 25;
            GUI.Label(new Rect(xpos, ypos, 200, 20), string.Concat("Name: ", this.currentObject.name), style);
            ypos += 25;
            GUI.Label(new Rect(xpos, ypos, 200, 20), string.Concat("Health: ", this.currentObject.Data.health), style);
            ypos += 25;
            GUI.Label(new Rect(xpos, ypos, 200, 20), string.Concat("Damage: ", this.currentObject.Data.damage), style);
            ypos += 25;
            GUI.Label(new Rect(xpos, ypos, 200, 20), string.Concat("Armor: ", this.currentObject.Data.armor), style);
            ypos += 25;
            GUI.Label(new Rect(xpos, ypos, 200, 20), string.Concat("Damage: ", this.currentObject.Data.damage), style);
            ypos += 25;
            GUI.Label(new Rect(xpos, ypos, 200, 20), string.Concat("Energy Usage: ", this.currentObject.Data.energyUsage), style);

            ypos += 30;
            if (GUI.Button(new Rect(xpos, ypos, 200, 40), string.Concat("Upgrade:", this.currentObject.Data.upgradePrice), buttonStyle))
            {

            }

            ypos += 45;
            if (GUI.Button(new Rect(xpos, ypos, 200, 40), string.Concat("Sale:", (this.currentObject.Data.price * this.currentObject.Data.priceLost)), buttonStyle))
            {

            }
        }
    }
}