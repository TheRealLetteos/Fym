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
        public Queue<GameObject> pool { get; private set; }

        //private int availableIndex = 0;

        public void initialize()
        {
            Debug.Log(poolName + " is initializing...");
            //availableIndex = 0;
            if (poolSize <= 0)
            {
                Debug.LogWarning("Pool size must be greater than 0");
                return;
            }
            pool = new Queue<GameObject>();
            for (int i = 0; i < poolSize; i++)
            {
                GameObject go = Instantiate(prefab, transform);
                go.SetActive(false);
                pool.Enqueue(go);
                Debug.Log("Object :" + go.name + " created");
            };
        }


        public void Reinitialize()
        {
            foreach (var go in pool)
            {
                go.SetActive(false);
            }
            //availableIndex = 0;
        }

        public bool ReturnObject(GameObject obj)
        {
            if (obj == null)
            {
                Debug.LogWarning("Object is null");
                return false;
            }
            Debug.Log("Returning object " + obj.name + " to pool " + poolName);
            obj.SetActive(false);
            pool.Enqueue(obj);
            return true;
        }

        public GameObject GetObject()
        {
            if (pool.Count <= 0)
            {
                Debug.LogWarning("No available object in pool");
                if(autoResize)
                {
                    for (int i = poolSize; i < Mathf.Min(MaxPoolSize, poolSize * 2); i++)
                    {
                        GameObject go = Instantiate(prefab, transform);
                        go.SetActive(false);
                        pool.Enqueue(go);
                    }
                    poolSize = Mathf.Min(MaxPoolSize, poolSize * 2);
                }
                else
                {
                    Debug.Log("Pool " + poolName + " is empty, no game object is available");
                    return null;
                }
            }
            Debug.Log("Getting object from pool " + poolName);
            GameObject objFromPool = pool.Dequeue();
            return objFromPool;
        }

        void FixedUpdate()
        {
            /*int last = availableIndex;
            for (int i = last - 1; i >= 0; i--)
            {
                if (!pool[i].activeSelf)
                {
                    GameObject temp = pool[availableIndex-1];
                    pool[availableIndex-1] = pool[i];
                    pool[i] = temp;
                    availableIndex--;
                }
            }*/
        }
    }
}