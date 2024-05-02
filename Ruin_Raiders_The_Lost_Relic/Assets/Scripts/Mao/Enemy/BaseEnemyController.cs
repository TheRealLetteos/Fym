using fym;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class BaseEnemyController : MonoBehaviour
    {

        public float maxHealth = 1.0f;

        //set to 1 for testing
        private float health;

        public float physicalDamage = 1.0f;

        public GameObjectPool projectilePool;

        private bool isBeingAttacked = false;

        void Awake()
        {
            health = maxHealth;
        }

        public void Attack(Player player)
        {
            // player takes damage

            // if player class detects collision with enemy, player takes damage itself, no need to call this function
        }

        public void Shoot(Vector2 direction)
        {
            Debug.Log("NPC is shooting at player.");

            GameObject projectile = projectilePool.GetObject();
            if (projectile == null)
            {
                Debug.Log("Projectile pool is empty.");
                return;
            }
            projectile.transform.position = transform.position;
            projectile.GetComponent<Rigidbody2D>().AddForce(direction * 10, ForceMode2D.Impulse);
            BaseProjectileController projectileController = projectile.GetComponent<BaseProjectileController>();
            projectileController.direction = direction;
            projectile.SetActive(true);
        }

        public void TakeDamage(float damage)
        {
            if(health > 0)
            {
                health -= damage;
                // damage is taken, set to false so that player can attack again
                // and to avoid multiple damage
                isBeingAttacked = false;
            }
            if(health <= 0)
            {
                projectilePool.Reinitialize();
                health = maxHealth;
                isBeingAttacked = false;
                gameObject.SetActive(false);
            }
        }

        public bool IsDead()
        {
            return health <= 0;
        }

        public bool IsBeingAttacked()
        {
            return isBeingAttacked;
        }

        //if enemy is being attacked by player, enemy takes damage, if enemy dies, enemy is reset and deactivated
        //so there will be no collision between player and dead enemy then
        void OnCollisionEnter2D(Collision2D collision)
        {
            string colliderTag = collision.gameObject.tag;

            if (collision.transform.CompareTag(GameManager.TAG_PLAYER))
            {
                //collision.gameObject.GetComponent<PlayerFSM>().TakeDamage(physicalDamage);
                //health -= physicalDamage;
                isBeingAttacked = true;
            }
        }

        void OnCollisionStay2D(Collision2D collision)
        {
            string colliderTag = collision.gameObject.tag;

            if (collision.transform.CompareTag(GameManager.TAG_PLAYER))
            {
                //collision.gameObject.GetComponent<PlayerFSM>().TakeDamage(physicalDamage);
                //health -= physicalDamage;
                //isBeingAttacked = true;
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            string colliderTag = collision.gameObject.tag;

            if (collision.transform.CompareTag(GameManager.TAG_PLAYER))
            {
                //collision.gameObject.GetComponent<PlayerFSM>().TakeDamage(physicalDamage);
                //health -= physicalDamage;
                isBeingAttacked = false;
            }
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