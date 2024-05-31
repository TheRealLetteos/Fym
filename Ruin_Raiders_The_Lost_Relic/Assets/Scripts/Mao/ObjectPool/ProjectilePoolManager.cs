using fym;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class ProjectilePoolManager : MonoBehaviour
    {

        [SerializeField]
        private Dictionary<string, ProjectilePool> npcProjectilePools =
            new Dictionary<string, ProjectilePool>();

        public List<ProjectilePool> allProjectilePools = new List<ProjectilePool>();

        public static ProjectilePoolManager Instance { get; private set; }

        public static int MAX_NPC_LEVEL = 0;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }

        private void Start()
        {
            foreach (ProjectilePool pool in allProjectilePools)
            {
                pool.Initialize();
                if (!npcProjectilePools.ContainsKey(pool.poolName))
                {
                    npcProjectilePools[pool.poolName] = pool;
                }
            }
        }

        public GameObject GetProjectileByPoolName(string poolName)
        {
            if (!npcProjectilePools.ContainsKey(poolName))
            {
                return null;
            }
            return npcProjectilePools[poolName].GetObject();
        }

        public void ReturnProjectileToPool()
        {
            foreach(ProjectilePool pool in allProjectilePools)
            {
                pool.Reinitialize();
            }
        }

    }
}
