﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{

    [CreateAssetMenu(fileName = "LevelList", menuName = "Level/LevelList")]
    public class LevelList : ScriptableObject
    {
        public List<LevelConfig> levelConfigs = new List<LevelConfig>();

        public static LevelList instance { get; private set; }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        public LevelConfig GetLevelConfig(int levelNumber)
        {
            if (levelNumber < 1 || levelNumber > LevelManager.MAX_LEVEL)
            {
                return levelConfigs[0];
            }
            return levelConfigs[levelNumber - 1];
        }
        

        public void AddLevel(LevelConfig levelConfig)
        {
            levelConfigs.Add(levelConfig);
        }

        public void RemoveLevel(int levelNumber)
        {
            if (levelNumber < 1 || levelNumber > LevelManager.MAX_LEVEL)
            {
                return;
            }
            levelConfigs.RemoveAt(levelNumber - 1);
        }
    }

}