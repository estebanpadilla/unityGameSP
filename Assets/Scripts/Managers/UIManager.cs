using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Texture2D buttonTexture;
    private GameManager gameManager;
    private Structure currentObject;
    public Structure CurrentObject { get { return this.currentObject; } set { this.currentObject = value; } }

    private float screenHeight = Screen.height;
    private float ypos;
    private float xpos;
    private float buttonHeight;
    private float buttonWidth;

    private GUIStyle style;
    private GUIStyle debugStyle;
    private GUIStyle buttonStyle;
    private string currentLevelName = "enter level name";

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        buttonWidth = 100.0f;
        buttonHeight = 50.0f;
        style = new GUIStyle();
        style.fontSize = 20;
        style.normal.textColor = Color.white;

        debugStyle = new GUIStyle();
        debugStyle.fontSize = 12;
        debugStyle.normal.textColor = Color.yellow;

        buttonStyle = new GUIStyle();
        buttonStyle.fontSize = 20;
        buttonStyle.normal.textColor = Color.black;
        buttonStyle.normal.background = buttonTexture;
        buttonStyle.alignment = TextAnchor.MiddleCenter;
    }

    void OnGUI()
    {
        //Player buttons
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
        if (GUI.Button(new Rect(xpos, ypos, buttonWidth, buttonHeight), "Meterial \nStorage", buttonStyle))
        {
            gameManager.addMaterialStorage();
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

        //Player data
        xpos = 10;
        ypos = 10;
        GUI.Label(new Rect(xpos, ypos, 100, 50), string.Concat("Cash:", gameManager.player.Cash), style);

        //Game object data
        if (currentObject != null)
        {
            ypos += 40;
            GUI.Label(new Rect(xpos, ypos, 220, 20), "Current Structure", style);
            ypos += 25;
            GUI.Label(new Rect(xpos, ypos, 220, 20), string.Concat("Identifier: ", this.currentObject.Data.identifier), style);
            ypos += 25;
            GUI.Label(new Rect(xpos, ypos, 220, 20), string.Concat("Price: ", this.currentObject.Data.price), style);
            ypos += 25;
            GUI.Label(new Rect(xpos, ypos, 220, 20), string.Concat("Name: ", this.currentObject.name), style);
            ypos += 25;
            GUI.Label(new Rect(xpos, ypos, 220, 20), string.Concat("Health: ", this.currentObject.Data.health), style);
            ypos += 25;
            GUI.Label(new Rect(xpos, ypos, 220, 20), string.Concat("Damage: ", this.currentObject.Data.damage), style);
            ypos += 25;
            GUI.Label(new Rect(xpos, ypos, 220, 20), string.Concat("Armor: ", this.currentObject.Data.armor), style);
            ypos += 25;
            GUI.Label(new Rect(xpos, ypos, 220, 20), string.Concat("Damage: ", this.currentObject.Data.damage), style);


            string text = "";
            foreach (int item in this.currentObject.Data.ins)
            {
                text += item;
                text += ", ";
            }

            ypos += 25;
            GUI.Label(new Rect(xpos, ypos, 220, 20), string.Concat("ins: ", text), style);

            text = "";
            foreach (int item in this.currentObject.Data.outs)
            {
                text += item;
                text += ", ";
            }

            ypos += 25;
            GUI.Label(new Rect(xpos, ypos, 220, 20), string.Concat("outs: ", text), style);

            ypos += 25;
            GUI.Label(new Rect(xpos, ypos, 220, 20), string.Concat("Energy Usage: ", this.currentObject.Data.energyUsage), style);

            ypos += 30;
            if (GUI.Button(new Rect(xpos, ypos, 220, 40), string.Concat("Upgrade:", this.currentObject.Data.upgradePrice), buttonStyle))
            {

            }

            ypos += 45;
            if (GUI.Button(new Rect(xpos, ypos, 220, 40), string.Concat("Sale:", (this.currentObject.Data.price * this.currentObject.Data.priceLost)), buttonStyle))
            {

            }
        }

        //Level creation data

        ypos += 45;
        GUI.Label(new Rect(xpos, ypos, 220, 20), ("Level: " + gameManager.DataManager.CurrenLevel), style);

        ypos += 25;
        gameManager.DataManager.CurrenLevel = GUI.TextField(new Rect(xpos, ypos, 220, 20), gameManager.DataManager.CurrenLevel);

        ypos += 30;
        if (GUI.Button(new Rect(xpos, ypos, 40, 40), "1", buttonStyle))
        {
            gameManager.addAsteroid(1);
        }

        xpos += 45;
        if (GUI.Button(new Rect(xpos, ypos, 40, 40), "2", buttonStyle))
        {
            gameManager.addAsteroid(2);
        }

        xpos += 45;
        if (GUI.Button(new Rect(xpos, ypos, 40, 40), "3", buttonStyle))
        {
            gameManager.addAsteroid(3);
        }

        xpos += 45;
        if (GUI.Button(new Rect(xpos, ypos, 40, 40), "4", buttonStyle))
        {
            gameManager.addAsteroid(4);
        }

        xpos += 45;
        if (GUI.Button(new Rect(xpos, ypos, 40, 40), "5", buttonStyle))
        {
            gameManager.addAsteroid(5);
        }

        xpos = 10;
        ypos += 45;
        if (GUI.Button(new Rect(xpos, ypos, 220, 40), "Load", buttonStyle))
        {
            //gameManager.DataManager.loadGameLevelsData();
        }

        ypos += 45;
        if (GUI.Button(new Rect(xpos, ypos, 220, 40), "Save", buttonStyle))
        {
            gameManager.saveLevelData();
        }

        foreach (GameObject item in gameManager.Pool.Values)
        {

            GameObjectData data = item.GetComponent<Structure>().Data;

            if (data.identifier == 5)
            {
                Vector3 point = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().WorldToScreenPoint(item.transform.position);
                point.y = (720 - point.y);
                GUI.Label(new Rect(point.x, point.y, 20, 100), ("minerals:" + data.productionQty), debugStyle);
            }

            //Show solar station energy level
            if (data.identifier == 2)
            {
                Vector3 point = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().WorldToScreenPoint(item.transform.position);
                point.y = (720 - point.y);
                GUI.Label(new Rect(point.x, point.y, 20, 100), ("Energy:" + data.productionQty), debugStyle);
            }
        }
    }
}
