using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{

    public class LevelManager : MonoBehaviour
    {

        public const int MAX_LEVEL = 99;

        public const int MAX_ENEMY_COUNT = 49;

        public const int MAX_ENEMY_LEVEL = 99;

        public const float MAX_SPAWN_DENSITY = 0.3f;

        public const float MAX_SPAWN_RANGE = 20.0f;

        public const float MAX_SCREEN_WIDTH = 1920.0f;

        public const float MAX_SCREEN_HEIGHT = 1080.0f;

        public const float MAX_LEVEL_DIFFICULTY = 30;

        public static LevelManager instance { get; private set; }

        public int currentLevel { get; private set; }

        public LevelList allLevels { get; private set; }


        // Start is called before the first frame update
        void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        public void IncreaseLevel()
        {
            currentLevel++;
            if(currentLevel > MAX_LEVEL)
            {
                currentLevel = 1;
            }
        }

        public LevelConfig GetLevelConfig(int levelNumber)
        {
            if(levelNumber < 1 || levelNumber > MAX_LEVEL)
            {
                return null;
            }
            return allLevels.GetLevelConfig(levelNumber);
        }
    }
}