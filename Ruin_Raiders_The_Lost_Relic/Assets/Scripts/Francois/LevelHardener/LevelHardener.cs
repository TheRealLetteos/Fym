using UnityEngine;
using UnityEngine.UI;

public class LevelHardener : MonoBehaviour
{
    public Slider difficultySlider;
    public LevelManager levelManager;

    private int lastDifficultyLevel = 0;

    void Start()
    {
        difficultySlider.onValueChanged.AddListener(delegate { AdjustLevelDifficulty(); });

        Debug.Log("Salut, je suis LevelHardener!");
    }

    void AdjustLevelDifficulty()
    {
        int currentDifficultyLevel = Mathf.FloorToInt(difficultySlider.value);

        if (currentDifficultyLevel > lastDifficultyLevel)
        {
            for (int i = lastDifficultyLevel; i < currentDifficultyLevel; i++)
            {
                levelManager.ApplyRandomObstacle();
            }
        }

        lastDifficultyLevel = currentDifficultyLevel;  // Update the last difficulty level
    }
}