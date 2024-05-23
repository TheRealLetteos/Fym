using fym;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class NPCPoolManager : MonoBehaviour
    {

        [SerializeField]
        private Dictionary<int, List<NPCPool>> levelingNPCPools =
            new Dictionary<int, List<NPCPool>>();

        private Dictionary<string, NPCPool> npcPools =
            new Dictionary<string, NPCPool>();

        public List<NPCPool> allNPCPools = new List<NPCPool>();

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
            foreach (NPCPool pool in allNPCPools)
            {
                pool.Initialize();
                if(!npcPools.ContainsKey(pool.poolName))
                {
                    npcPools[pool.poolName] = pool;
                }
                if (!levelingNPCPools.ContainsKey(pool.npcLevel))
                {
                    levelingNPCPools[pool.npcLevel] = new List<NPCPool>();
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
            List<NPCPool> pools = levelingNPCPools[level];
            if (pools.Count == 0)
            {
                return null;
            }
            int randomIndex = Random.Range(0, pools.Count);
            NPCPool pool = pools[randomIndex];
            return pool.GetObject();
        }

        public GameObject GetNPCByName(string npcName)
        {
            if(npcPools.ContainsKey(npcName))
            {
                return npcPools[npcName].GetObject();
            }
            return null;
        }

        /*public void ReturnNPCToPool(string poolName, GameObject npc)
        {
            if(npcPools.ContainsKey(poolName))
            {
                npcPools[poolName].ReturnObject(npc);
            }
            else
            {
                Destroy(npc);
            }
        }*/

    }
}
