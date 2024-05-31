using UnityEngine;
using UnityEngine.UI;

public class LevelHardenerInGame : MonoBehaviour
{
    public Slider difficultySlider;
    public LevelManager levelManager;

    private int lastDifficultyLevel = 0;

    void Start()
    {
        
    }

    void AdjustLevelDifficulty()
    {
        int currentDifficultyLevel = Mathf.FloorToInt(difficultySlider.value);
        currentDifficultyLevel = Mathf.Min(currentDifficultyLevel, 100); //cap difficulty at 100
        if (currentDifficultyLevel > lastDifficultyLevel)
        {
            for (int i = lastDifficultyLevel; i < currentDifficultyLevel; i++)
            {
                levelManager.ApplyRandomObstacle();
            } // note: we can reach higher than 100 difficulty (max allowed by slider) by dragging over and over again. This is on purpose for testing/balancing!
        }

        lastDifficultyLevel = currentDifficultyLevel;  // Update the last difficulty level
    }
}