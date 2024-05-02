using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{

    public class GameObjectPool : MonoBehaviour, IPool<GameObject>
    {

        [SerializeField] private bool autoResize = false;

        [SerializeField]
        private GameObject prefab;

        [SerializeField]
        private int poolSize = 10;

        [SerializeField]
        public GameObject[] pool { get; private set; }

        private int availableIndex = 0;

        void Awake()
        {
            if (poolSize <= 0)
            {
                Debug.LogWarning("Pool size must be greater than 0");
                return;
            }
            pool = new GameObject[poolSize];
            for (int i = 0; i < poolSize; i++)
            {
                pool[i] = Instantiate(prefab, transform);
                pool[i].SetActive(false);
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
                    GameObject[] newPool = new GameObject[poolSize * 2];
                    for (int i = 0; i < poolSize; i++)
                    {
                        newPool[i] = pool[i];
                    }
                    for (int i = poolSize; i < poolSize * 2; i++)
                    {
                        newPool[i] = Instantiate(prefab, transform);
                        newPool[i].SetActive(false);
                    }
                    pool = newPool;
                    poolSize *= 2;
                }
                else
                    return null;
            }

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