using fym;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class NPCPoolManager : MonoBehaviour
    {

        [SerializeField]
        private Dictionary<int, List<GameObjectPool>> levelingNPCPools =
            new Dictionary<int, List<GameObjectPool>>();



        public List<GameObjectPool> allNPCPools = new List<GameObjectPool>();

        public static NPCPoolManager Instance { get; private set; }

        public static int MAX_NPC_LEVEL = 0;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private void Start()
        {
            foreach (GameObjectPool pool in allNPCPools)
            {
                pool.initialize();
                if (!levelingNPCPools.ContainsKey(pool.npcLevel))
                {
                    levelingNPCPools[pool.npcLevel] = new List<GameObjectPool>();
                }
                levelingNPCPools[pool.npcLevel].Add(pool);
                if (pool.npcLevel > MAX_NPC_LEVEL)
                {
                    MAX_NPC_LEVEL = pool.npcLevel;
                }
            }
        }

        public GameObject GetRandomNPCByLevel(int level)
        {
            if (!levelingNPCPools.ContainsKey(level))
            {
                return null;
            }
            List<GameObjectPool> pools = levelingNPCPools[level];
            if (pools.Count == 0)
            {
                return null;
            }
            int randomIndex = Random.Range(0, pools.Count);
            GameObjectPool pool = pools[randomIndex];
            return pool.GetObject();
        }

    }
}
