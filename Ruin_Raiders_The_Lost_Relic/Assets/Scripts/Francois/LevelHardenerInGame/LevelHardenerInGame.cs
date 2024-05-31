using fym;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class LevelHardenerInGame : MonoBehaviour
{

    //public LevelManager levelManager;
    private LevelManagerInGame levelManagerScript;
    private GameManager gameManager;
    private int lastDifficultyLevel = 0;
    public int difficulty;

    void Start()
    {
        gameManager = GameManager.Instance;

        if (gameManager != null) 
        {
            difficulty = gameManager.difficulty;
            Debug.Log("GameManager Found!");
            Debug.Log("Difficulty is set at :" + difficulty);
        }

        // Find the GameObject named "LevelHardener" and get the LevelHardenerInGame script attached to it
        GameObject levelHardenerObject = GameObject.Find("LevelHardener");
        if (levelHardenerObject != null)
        {
            levelManagerScript = levelHardenerObject.GetComponent<LevelManagerInGame>();
            if (levelManagerScript != null)
            {

                AdjustLevelDifficulty();
                Debug.Log("APPLY DIFFICULTY");
            }
            else
            {
                Debug.LogError("LevelHardenerInGame script not found on 'LevelHardener' object!");
            }
        }
        else
        {
            Debug.LogError("GameObject named 'LevelHardener' not found!");
        }
    }

    void AdjustLevelDifficulty()
    {
            for (int i = 0; i < gameManager.difficulty; i++)
            {
                levelManagerScript.ApplyRandomObstacle();
            } 
    }
}