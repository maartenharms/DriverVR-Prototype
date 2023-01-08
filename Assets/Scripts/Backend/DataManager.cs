using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataManagement
{
    public class DataManager : MonoBehaviour
    {
        public static GameObject managerInstance;
        public static Dictionary<string, LevelData> levelData = new Dictionary<string, LevelData>();

        void Awake()
        {
            if (managerInstance != null)
                Destroy(gameObject);

            managerInstance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
    }
}

