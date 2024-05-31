using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{

    [CreateAssetMenu(fileName = "LevelList", menuName = "Level/LevelList")]
    public class LevelList : ScriptableObject
    {
        public List<LevelConfig> levelConfigs = new List<LevelConfig>();

        public int LevelCount { get { return levelConfigs.Count; } }

        /*public static LevelList instance { get; private set; }

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
        }*/

        public LevelConfig GetLevelConfig(int levelNumber)
        {
            if (levelNumber < 0 || levelNumber >= levelConfigs.Count)
            {
                return null;
            }
            return levelConfigs[levelNumber];
        }
        

        /*public void AddLevel(LevelConfig levelConfig)
        {
            levelConfigs.Add(levelConfig);
        }

        // please don't do that
        public void RemoveLevel(int levelNumber)
        {
            if (levelNumber < 0 || levelNumber > LevelManager.MAX_LEVEL)
            {
                return;
            }
            levelConfigs.Remove(GetLevelConfig(levelNumber));
        }*/
    }

}