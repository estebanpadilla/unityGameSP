using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class AsteroidLevelData
{
    public AsteroidLevelData(string name, Vector3 position)
    {
        this.name = name;
        this.position = position;
    }
    public Vector3 position;
    public string name;
}

[System.Serializable]
public class GameLevelData
{
    /*Lvel variables.*/
    public int identifier;
    public string name;

    public List<AsteroidLevelData> asteroids;

    public string[] descriptions;
}

