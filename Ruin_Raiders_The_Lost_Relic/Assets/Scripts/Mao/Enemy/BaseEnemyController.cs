using fym;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class BaseEnemyController : MonoBehaviour
    {

        public GameObjectPool projectilePool;

        public void Attack()
        {

        }

        public void Shoot()
        {
            GameObject projectile = projectilePool.GetObject();
            projectile.transform.position = transform.position;
            projectile.GetComponent<Rigidbody>().velocity = transform.forward * 10;
        }

        public void Start()
        {
        }

        public void TakeDamage(float damage)
        {
            throw new NotImplementedException();
        }
    }
}