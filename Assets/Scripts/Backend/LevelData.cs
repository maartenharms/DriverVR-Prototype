using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    public string levelName;
    public Dictionary<int, bool> obstacleCompletion = new Dictionary<int, bool>();

    public LevelData(string _level, Dictionary<int,bool> _data) 
    {
        levelName = _level;
        obstacleCompletion = _data;
    }
}
