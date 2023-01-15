using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Score;
using DataManagement;
using Currency;

public class ObstacleManager : MonoBehaviour
{
    private Dictionary<int, Obstacle> obstacles = new Dictionary<int, Obstacle>();
    private int failmarks;
    [SerializeField] private int maxFailmarks;

    // Start is called before the first frame update
    private void Awake()
    {
        GameObject[] allObstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        foreach (GameObject obj in allObstacles) 
        {
            int instanceID = obj.GetInstanceID();

            // Skip to next loop if list already has the instance ID
            if (obstacles.ContainsKey(instanceID))
                continue;

            // If it didn't, add the actor and instance ID
            Obstacle _obstacle = obj.GetComponent<Obstacle>();
            obstacles.Add(instanceID, _obstacle);
            _obstacle.onCompleteTrigger += ScoreSystem.AddScore;
            _obstacle.onFailTrigger += OnFailingObstacle;
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

    public void OnFailingObstacle()
    {
        failmarks++;
        Debug.Log($"You failed {failmarks} times you dingus");
        if(failmarks >= maxFailmarks)
            LevelFail();
    }

    private void LevelFail()
    {
        Debug.Log("level failed");
    }

    public void OnLevelCompletion() 
    {
        // Get scene name as level name
        string levelname = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        // Create LevelData variable from gathered data
        // Save it in a global script
        LevelData leveldata = CreateLevelData(levelname);

        CalculateCurrency(levelname, leveldata.obstacleCompletion);
        SceneManager.LoadScene(0);
        Debug.Log("wut?");
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
