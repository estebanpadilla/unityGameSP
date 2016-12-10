using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class DataManager
{
    //Instance Variables
    protected Dictionary<string, GameObjectData> gameObjectsData = new Dictionary<string, GameObjectData>();
    public Dictionary<string, GameObjectData> GameObjectsData { get { return this.gameObjectsData; } set { this.gameObjectsData = value; } }

    protected string currentLevel = "level1";
    public string CurrenLevel { get { return this.currentLevel; } set { this.currentLevel = value; } }

    protected Dictionary<string, GameLevelData> gameLevelsData = new Dictionary<string, GameLevelData>();
    public Dictionary<string, GameLevelData> GameLevelsData { get { return this.gameLevelsData; } set { this.gameLevelsData = value; } }

    public DataManager()
    {

    }

    public void loadGameObjectsData()
    {
        TextAsset jsonData = Resources.Load(Path.Combine("Data", "gameObjectsData")) as TextAsset;
        string json = jsonData.ToString();

        List<GameObjectData> objects;
        objects = JsonHelper.FromJson<GameObjectData>(json);

        if (objects != null)
        {
            foreach (GameObjectData item in objects)
            {
                gameObjectsData.Add(item.name, item);
            }
        }
    }

    public void saveGameLevelsData()
    {
        string json = JsonHelper.ToJson(new List<GameLevelData>(this.gameLevelsData.Values));
        string path = Application.dataPath + "/Resources/Data/gameLevelsData.json";
        Debug.Log("Save levels data to:" + path);
        File.WriteAllText(path, json);
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }

    public void loadGameLevelsData()
    {
        gameLevelsData.Clear();

        TextAsset jsonData = Resources.Load(Path.Combine("Data", "gameLevelsData")) as TextAsset;
        string json = jsonData.ToString();

        List<GameLevelData> levelsData;
        levelsData = JsonHelper.FromJson<GameLevelData>(json);

        if (levelsData != null)
        {
            foreach (GameLevelData item in levelsData)
            {
                gameLevelsData.Add(item.name, item);
            }
        }
    }

    public GameObjectData findGameObjectData(string key)
    {
        return gameObjectsData[key];
    }

    public void addAsteroidsToLevel(List<AsteroidLevelData> list)
    {
        gameLevelsData[currentLevel].asteroids.Clear();
        gameLevelsData[currentLevel].asteroids = list;
    }


}
