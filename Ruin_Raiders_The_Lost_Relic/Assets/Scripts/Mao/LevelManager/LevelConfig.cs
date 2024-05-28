
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

        public string bgmName;

        public Vector3 playerStartPos;

        public Vector3 screenCenterPos;

        public string levelPath;

        public string levelName;

        public static LevelConfig CreateLevelConfig(
            Vector3 screenCenterPos,
            Vector3 playerStartPos,
            string levelPath,
            string levelName,
            string bgmName,
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
            config.playerStartPos = playerStartPos;
            config.levelPath = levelPath;
            config.levelName = levelName;
            config.bgmName = bgmName;
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

        public static LevelConfig GetRandomLevelConfig(
            Vector3 center, Vector3 playerStartPos, string levelPath, string levelName, string bgmName, float screenWidth, float screenHeight, int ln)
        {
            var random = new System.Random();
            if (ln < 1 || ln > LevelManager.MAX_LEVEL)
            {
                return CreateLevelConfig(center, playerStartPos, "Assets/Scene/SampleScene.unity", "SampleScene", "MusicClip_1", ln = 1);
            }
            int enemyCount = 5 + ln / 2;
            float enemyLevel = (float)random.NextDouble() % ln + ln;
            float spawnDensity = 0.05f + ln / 100.0f;
            float spawnRange = 15.0f + ln / 2.0f;
            //float screenWidth = 1920.0f;
            //float screenHeight = 1080.0f;
            float levelDifficulty = 1 + ln / 3;
            return CreateLevelConfig(center, playerStartPos, levelPath, levelName, bgmName, ln, enemyCount, enemyLevel, spawnDensity, spawnRange, screenWidth, screenHeight, levelDifficulty);
        }

    }
}