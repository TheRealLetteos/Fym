using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{

    public class GameObjectPool : MonoBehaviour, IPool<GameObject>
    {

        public bool isDebug = false;

        public int npcLevel = 1;

        public string poolName;

        public int MaxPoolSize { get; set; } = 40;

        [SerializeField] private bool autoResize = false;

        [SerializeField]
        private GameObject prefab;

        [SerializeField]
        public int poolSize = 10;

        public List<GameObject> pool { get; private set; } = new List<GameObject>();

        private List<int> activity = new List<int>();

        //private int availableIndex = 0;

        public void Initialize()
        {
            Debug.Log(poolName + " is initializing...");
            //availableIndex = 0;
            if (poolSize <= 0)
            {
                Debug.LogWarning("Pool size must be greater than 0");
                return;
            }
            for (int i = 0; i < poolSize; i++)
            {
                GameObject go = Instantiate(prefab, transform);
                go.SetActive(false);
                pool.Add(go);
                activity.Add(i);
                Debug.Log("Object :" + go.name + " created");
            };
        }


        public void Reinitialize()
        {
            activity.Clear();
            for (int i=0;i<poolSize;i++)
            {
                pool[i].SetActive(false);
                activity.Add(i);
            }
            //availableIndex = 0;
        }

        /*public bool ReturnObject(GameObject obj)
        {
            if(isDebug)
            {
                Debug.Log("Returning object " + obj.name + " to pool " + poolName);
                Destroy(obj);
                return true;
            }
            if (obj == null)
            {
                Debug.LogWarning("Object is null");
                return false;
            }
            Debug.Log("Returning object " + obj.name + " to pool " + poolName);
            obj.SetActive(false);
            availableObjectPool.Enqueue(obj);
            return true;
        }*/

        public GameObject GetObject()
        {
            if (isDebug)
            {
                Debug.Log("Getting object from pool " + poolName);
                return Instantiate(prefab, transform);
            }
            if (activity.Count <= 0)
            {
                Debug.LogWarning("No available object in pool");
                if(autoResize)
                {
                    /*for (int i = poolSize; i < Mathf.Min(MaxPoolSize, poolSize * 2); i++)
                    {
                        GameObject go = Instantiate(prefab, transform);
                        go.SetActive(false);
                        pool.Add(go);
                        activity.Add(i);
                    }
                    poolSize = Mathf.Min(MaxPoolSize, poolSize * 2);*/
                    Debug.Log("Unsupport auto resize");
                    return null;
                }
                else
                {
                    Debug.Log("Pool " + poolName + " is empty, no game object is available");
                    return null;
                }
            }
            Debug.Log("Getting object from pool " + poolName);
            int index = activity[activity.Count - 1];
            GameObject objFromPool = pool[index];
            activity.RemoveAt(activity.Count - 1);
            return objFromPool;
        }

        void Update()
        {
            if(pool == null)
            {
                Debug.Log("Pool is not initialized");
                return;
            }
            for (int i = 0; i < pool.Count;i++)
            {
                if (!pool[i].activeSelf && !activity.Contains(i))
                {
                    Debug.Log("Object " + pool[i].name + " is inactive");
                    activity.Add(i);
                }
            }
        }
    }
}