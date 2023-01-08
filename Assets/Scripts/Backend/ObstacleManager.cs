using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Score;
using DataManagement;
using Currency;

public class ObstacleManager : MonoBehaviour
{
    private Dictionary<int, Obstacle> obstacles = new Dictionary<int, Obstacle>();

    // Start is called before the first frame update
    private void Awake()
    {
        GameObject endGoal = GameObject.FindGameObjectWithTag("LevelGoal");
        endGoal.GetComponent<LevelGoal>().onReachingGoal += OnLevelCompletion;

        GameObject[] _obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        foreach (GameObject obj in _obstacles) 
        {
            int instanceID = obj.GetInstanceID();
            Debug.Log($"{obj.name}, {instanceID}");

            // Skip to next loop if list already has the instance ID
            if (obstacles.ContainsKey(instanceID))
                continue;

            // If it didn't, add the actor and instance ID
            obstacles.Add(instanceID, obj.GetComponent<Obstacle>());
            obj.GetComponent<Obstacle>().onCompleteTrigger += ScoreSystem.AddScore;
        }

        // Get scene name as level name
        string levelname = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        // Check if leveldata is present
        // If not, create and save leveldata
        if (!DataManager.levelData.ContainsKey(levelname))
        {
            LevelData leveldata = CreateLevelData(levelname);
            DataManager.levelData.Add(levelname, leveldata);
        }
    }

    public void OnLevelCompletion() 
    {
        // Get scene name as level name
        string levelname = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        // Create LevelData variable from gathered data
        // Save it in a global script
        LevelData leveldata = CreateLevelData(levelname);

        CalculateCurrency(levelname, leveldata.obstacleCompletion);

        Debug.Log("pray");
    }

    private LevelData CreateLevelData(string levelname) 
    {
        Dictionary<int, bool> obstacleData = new Dictionary<int, bool>();

        // Itterate through obstacles to gather completion data
        foreach (int key in obstacles.Keys)
        {
            bool isComplete = obstacles[key].isCompleted;
            obstacleData.Add(key, isComplete);
        }

        // Create LevelData variable from gathered data
        // Save it in a global script
        LevelData leveldata = new LevelData(levelname, obstacleData);

        return leveldata;
    }

    // Add currency for every newly completed obstacle
    // If a completed obstacle has not been previously completed, mark it as such
    private void CalculateCurrency(string levelname, Dictionary<int, bool> obstacleData) 
    {
        LevelData oldData = DataManager.levelData[levelname];

        // Itterate through all scorable obtsacles in dictionary
        foreach (int key in obstacleData.Keys)
        {
            // Skip to next itteration if obstacle was not cleared
            if (obstacleData[key] == false)
                continue;

            // Check if obstacle was cleared in a previous playthrough of the level
            if (oldData.obstacleCompletion[key] == false) 
            {
                CurrencyManager.AddCurrency(obstacles[key].pointValue);
                DataManager.levelData[levelname].obstacleCompletion[key] = true;
            }
        }
    }
}
