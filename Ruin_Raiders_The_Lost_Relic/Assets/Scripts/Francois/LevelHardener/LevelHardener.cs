using UnityEngine;
using UnityEngine.UI;

public class LevelHardener : MonoBehaviour
{
    public Slider difficultySlider;
    public LevelManager levelManager; 

    void Start()
    {
        difficultySlider.onValueChanged.AddListener(delegate { AdjustLevelDifficulty(); });

        Debug.Log("Salut, je suis LevelHardener!");
    }

    void AdjustLevelDifficulty()
    {
        int difficultyLevel = Mathf.FloorToInt(difficultySlider.value);
        for (int i = 0; i < difficultyLevel; i++)
        {
            levelManager.ApplyRandomObstacle();
        }
    }
}