
using UnityEngine;

namespace fym
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Level/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {

        public int levelNumber;

        public int enemyCount;

        public float enemyLevel;

        public float spawnDensity;

        public float spawnRange;

        public float screenWidth;

        public float screenHeight;

        public float levelDifficulty;

        public UnityEngine.Vector2 screenCenterPos;

        public string levelPath;

        public static LevelConfig CreateLevelConfig(
            Vector2 screenCenterPos,
            int levelNumber = 1,
            int enemyCount = 5,
            float enemyLevel = 1,
            float spawnDensity = 0.05f,
            float spawnRange = 15.0f,
            float screenWidth = 1920f,
            float screenHeight = 1080f,
            float levelDifficulty = 1)
        {
            LevelConfig config = new LevelConfig();
            config.screenCenterPos = screenCenterPos;
            config.levelNumber = levelNumber;
            config.enemyCount = enemyCount;
            config.enemyLevel = enemyLevel;
            config.spawnDensity = spawnDensity;
            config.spawnRange = spawnRange;
            config.screenWidth = screenWidth;
            config.screenHeight = screenHeight;
            config.levelDifficulty = levelDifficulty;
            return config;
        }

        public static LevelConfig GetRandomLevelConfig(Vector2 center, float screenWidth, float screenHeight, int ln)
        {
            var random = new System.Random();
            if (ln < 1 || ln > LevelManager.MAX_LEVEL)
            {
                return CreateLevelConfig(center, ln = 1);
            }
            int enemyCount = 5 + ln / 2;
            float enemyLevel = (float)random.NextDouble() % ln + ln;
            float spawnDensity = 0.05f + ln / 100.0f;
            float spawnRange = 15.0f + ln / 2.0f;
            //float screenWidth = 1920.0f;
            //float screenHeight = 1080.0f;
            float levelDifficulty = 1 + ln / 3;
            return CreateLevelConfig(center, ln, enemyCount, enemyLevel, spawnDensity, spawnRange, screenWidth, screenHeight, levelDifficulty);
        }

    }
}