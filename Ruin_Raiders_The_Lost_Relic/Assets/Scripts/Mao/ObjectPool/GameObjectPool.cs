using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{

    public abstract class GameObjectPool<T> : MonoBehaviour
    {

        [SerializeField]
        protected bool isDebug = false;

        public string poolName;

        [SerializeField]
        protected int MaxPoolSize = 40;

        [SerializeField]
        protected bool autoResize = false;

        [SerializeField]
        protected GameObject prefab;

        public int poolSize = 10;

        protected List<GameObject> pool = new List<GameObject>();

        protected List<int> activity = new List<int>();

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
        }

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
                    int maxSize = Mathf.Min(MaxPoolSize, poolSize * 2);
                    for (int i = poolSize; i < maxSize; i++)
                    {
                        GameObject go = Instantiate(prefab, transform);
                        go.SetActive(false);
                        pool.Add(go);
                        activity.Add(i);
                    }
                    poolSize = maxSize;
                    //Debug.Log("Unsupport auto resize");
                    //return null;
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

        public abstract T GetObjectController(GameObject go);
    }
}