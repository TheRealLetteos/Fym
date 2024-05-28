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

        /*public bool ReturnProjectileToPool(string poolName, GameObject projectile)
        {
            if (!npcProjectilePools.ContainsKey(poolName))
            {
                Destroy(projectile);
                return false;
            }
            NPCPool pool = npcProjectilePools[poolName];
            pool.ReturnObject(projectile);
            return true;
        }*/

    }
}
