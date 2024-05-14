using fym;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class ProjectilePoolManager : MonoBehaviour
    {

        [SerializeField]
        private Dictionary<string, GameObjectPool> npcProjectilePools =
            new Dictionary<string, GameObjectPool>();

        public List<GameObjectPool> allProjectilePools = new List<GameObjectPool>();

        public static ProjectilePoolManager Instance { get; private set; }

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
            foreach (GameObjectPool pool in allProjectilePools)
            {
                pool.initialize();
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
            GameObjectPool pool = npcProjectilePools[poolName];
            return pool.GetObject();
        }

        public bool ReturnProjectileToPool(string poolName, GameObject projectile)
        {
            if (!npcProjectilePools.ContainsKey(poolName))
            {
                Destroy(projectile);
                return false;
            }
            GameObjectPool pool = npcProjectilePools[poolName];
            pool.ReturnObject(projectile);
            return true;
        }

    }
}
