using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playerPosition;
    public int buildIndex;
    public long lastUpdated;

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData() 
    {
        playerPosition = new Vector3(666,100,196);
        buildIndex = 1;
    }
}
