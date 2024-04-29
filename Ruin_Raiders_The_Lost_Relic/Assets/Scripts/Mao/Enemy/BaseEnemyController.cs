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

        public Vector2 direction { get; private set; }

        public void Attack(Vector2 direction)
        {

        }

        public void Shoot(Vector2 direction)
        {
            GameObject projectile = projectilePool.GetObject();
            if (projectile == null)
            projectile.transform.position = transform.position;
            projectile.GetComponent<Rigidbody>().velocity = transform.forward * 10;
            BaseProjectileController projectileController = projectile.GetComponent<BaseProjectileController>();
            projectileController.direction = direction;
            projectile.SetActive(true);
        }

        public void TakeDamage(float damage)
        {
            throw new NotImplementedException();
        }

        public Vector2 GetDirection()
        {
            return direction;
        }

        public void SetDirection(Vector2 direction)
        {
              this.direction = direction;
        }
    }
}