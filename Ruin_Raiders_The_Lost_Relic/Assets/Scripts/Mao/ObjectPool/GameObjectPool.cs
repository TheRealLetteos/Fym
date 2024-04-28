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

        private Queue<GameObject> pool = new Queue<GameObject>();

        void Awake()
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(prefab, transform);
                obj.SetActive(false);
                pool.Enqueue(obj);
            }
        }

        public GameObject GetObject()
        {
            if (pool.Count == 0)
            {
                GameObject obj = Instantiate(prefab, transform);
                pool.Enqueue(obj);
            }

            GameObject objFromPool = pool.Dequeue();
            objFromPool.SetActive(true);
            return objFromPool;
        }

        public virtual void ReturnObject(GameObject obj)
        {
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }
}