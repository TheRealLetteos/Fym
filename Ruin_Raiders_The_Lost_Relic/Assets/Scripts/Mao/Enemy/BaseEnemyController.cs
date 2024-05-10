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

        public GameObjectPool projectilePool = null;

        private bool isBeingAttacked = false;

        private bool isAttacking = false;

        void Awake()
        {
            health = maxHealth;
        }

        public void Attack(Player player)
        {
            // player takes damage

            // if player class detects collision with enemy, player takes damage itself, no need to call this function
            isAttacking = true;
        }

        public void Shoot(Vector2 direction)
        {
            Debug.Log("NPC is shooting at player.");
            isAttacking = true;
            if(projectilePool == null)
            {
                Debug.Log("Projectile pool is not set.");
                return;
            }
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
            Debug.Log("NPC has shot a projectile.");
        }

        public void TakeDamage(float damage)
        {
            isBeingAttacked = true;
            if(health > 0)
            {
                health -= damage;
                // damage is taken, set to false so that player can attack again
                // and to avoid multiple damage
            }
        }

        public bool IsDead()
        {
            return health <= 0;
        }

        public void Die()
        {
            if (projectilePool != null)
            {
                projectilePool.Reinitialize();
            }
            health = maxHealth;
            isBeingAttacked = false;
            gameObject.SetActive(false);
        }

        public bool IsBeingAttacked()
        {
            return isBeingAttacked;
        }

        public bool IsAttacking()
        {
            return isAttacking;
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

    }
}