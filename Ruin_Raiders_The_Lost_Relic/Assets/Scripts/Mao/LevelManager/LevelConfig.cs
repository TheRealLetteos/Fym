
using System;


namespace fym
{
    public class LevelConfig
    {

        public static LevelConfig currentLevelConfig { get; private set; }

        //when entering the game, the current level is always 1
        private static int CURRENT_LEVEL = 0;

        public const int MAX_LEVEL = 99;

        public int MAX_ENEMY_COUNT = 49;

        public int MAX_ENEMY_LEVEL = 99;

        public float MAX_SPAWN_DENSITY = 0.3f;

        public float MAX_SPAWN_RANGE = 20.0f;

        public float MAX_SCREEN_WIDTH = 1920.0f;

        public float MAX_SCREEN_HEIGHT = 1080.0f;

        public float MAX_LEVEL_DIFFICULTY = 30;

        public int levelNumber { get; private set; }

        public int enemyCount { get; private set; }

        public float enemyLevel { get; private set; }

        public float spawnDensity { get; private set; }

        public float spawnRange { get; private set; }

        public float screenWidth { get; private set; }

        public float screenHeight { get; private set; }

        public float levelDifficulty { get; private set; }

        public LevelConfig(
            int levelNumber = 1,
            int enemyCount = 5,
            float enemyLevel = 1,
            float spawnDensity = 0.05f,
            float spawnRange = 15.0f,
            float screenWidth = 1920f,
            float screenHeight = 1080f,
            float levelDifficulty = 1)
        {
            this.levelNumber = levelNumber;
            this.enemyCount = enemyCount;
            this.enemyLevel = enemyLevel;
            this.spawnDensity = spawnDensity;
            this.spawnRange = spawnRange;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.levelDifficulty = levelDifficulty;
        }

        public static LevelConfig GetLevelConfig(int ln)
        {
            var random = new Random();
            if (ln < 1 || ln > MAX_LEVEL)
            {
                return new LevelConfig(ln = 1);
            }
            int enemyCount = 5 + ln / 2;
            float enemyLevel = (float)random.NextDouble() % ln + ln;
            float spawnDensity = 0.05f + ln / 100.0f;
            float spawnRange = 15.0f + ln / 2.0f;
            float screenWidth = 1920.0f;
            float screenHeight = 1080.0f;
            float levelDifficulty = 1 + ln / 3;
            return new LevelConfig(ln, enemyCount, enemyLevel, spawnDensity, spawnRange, screenWidth, screenHeight, levelDifficulty);
        }

        public static LevelConfig GetNextLevelConfig()
        {
            if (CURRENT_LEVEL >= MAX_LEVEL)
            {
                return null;
            }
            CURRENT_LEVEL++;
            currentLevelConfig = GetLevelConfig(CURRENT_LEVEL);
            return currentLevelConfig;
        }

        public static void ResetLevel()
        {
            CURRENT_LEVEL = 0;
        }

    }
}