using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{

    public class GameObjectPool : MonoBehaviour, IPool<GameObject>
    {

        public int npcLevel = 1;

        public string poolName;

        public int MaxPoolSize { get; set; } = 40;

        [SerializeField] private bool autoResize = false;

        [SerializeField]
        private GameObject prefab;

        [SerializeField]
        public int poolSize = 10;

        [SerializeField]
        public List<GameObject> pool { get; private set; }

        private int availableIndex = 0;

        void Start()
        {
            availableIndex = 0;
            if (poolSize <= 0)
            {
                Debug.LogWarning("Pool size must be greater than 0");
                return;
            }
            pool = new List<GameObject>();
            for (int i = 0; i < poolSize; i++)
            {
                GameObject go = Instantiate(prefab, transform);
                go.SetActive(false);
                pool.Add(go);
                Debug.Log("Object :" + pool[i].name + " created");
            };
        }


        public void Reinitialize()
        {
            for(int i = 0; i < poolSize; i++)
            {
                pool[i].SetActive(false);
            }
            availableIndex = 0;
        }

        public GameObject GetObject()
        {
            if (availableIndex >= poolSize)
            {
                Debug.LogWarning("No available object in pool");
                if(autoResize)
                {
                    for (int i = poolSize; i < Mathf.Min(MaxPoolSize, poolSize * 2); i++)
                    {
                        GameObject go = Instantiate(prefab, transform);
                        go.SetActive(false);
                        pool.Add(go);
                    }
                    poolSize = Mathf.Min(MaxPoolSize, poolSize * 2);
                }
                else
                {
                    Debug.Log("Get no object in pool");
                    return null;
                }
            }
            Debug.Log("Get object from pool");
            GameObject objFromPool = pool[availableIndex++];
            objFromPool.SetActive(true);
            return objFromPool;
        }

        void FixedUpdate()
        {
            int last = availableIndex;
            for (int i = last - 1; i >= 0; i--)
            {
                if (!pool[i].activeSelf)
                {
                    GameObject temp = pool[availableIndex-1];
                    pool[availableIndex-1] = pool[i];
                    pool[i] = temp;
                    availableIndex--;
                }
            }
        }
    }
}