using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{

    public class GameObjectPool : MonoBehaviour
    {

        [SerializeField]
        private GameObject prefab;

        [SerializeField]
        private int poolSize = 10;

        private GameObject[] pool;

        private int availableIndex = 0;

        void Awake()
        {
            pool = new GameObject[poolSize];
            for (int i = 0; i < poolSize; i++)
            {
                pool[i] = Instantiate(prefab, transform);
                pool[i].SetActive(false);
            }
        }

        public GameObject GetObject()
        {
            if (availableIndex >= poolSize)
            {
                Debug.LogWarning("No available object in pool");
                return null;
            }

            GameObject objFromPool = pool[availableIndex++];
            objFromPool.SetActive(true);
            return objFromPool;
        }

        private void FixedUpdate()
        {
            int last = availableIndex;
            for (int i = 0; i < last; i++)
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