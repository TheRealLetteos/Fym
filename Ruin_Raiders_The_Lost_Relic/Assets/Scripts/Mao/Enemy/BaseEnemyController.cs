using fym;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class BaseEnemyController : MonoBehaviour
    {

        public string npcName;

        public string projetilePoolName;

        public float maxHealth = 1.0f;

        //set to 1 for testing
        private float health;

        public float physicalDamage = 1.0f;

        private bool isBeingAttacked = false;

        private bool isAttacking = false;

        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Initialize()
        {
            gameObject.SetActive(true);
            health = maxHealth;
            isBeingAttacked = false;
            isAttacking = false;
        }

        public void Attack(Player player)
        {
            // player takes damage
            Debug.Log("NPC : " + gameObject.name + "is attacking player.");

            // if player class detects collision with enemy, player takes damage itself, no need to call this function
            isAttacking = true;
            //animator.SetBool("IsAttack", true);
            animator.SetTrigger("AttackTrigger");
        }

        public void Shoot(Vector3 direction)
        {
            Debug.Log("NPC : " + gameObject.name + "is shooting at player.");
            isAttacking = true;
            //animator.SetBool("IsAttack", true);
            animator.SetTrigger("AttackTrigger");
            GameObject projectile = ProjectilePoolManager.Instance.GetProjectileByPoolName(projetilePoolName);
            if (projectile == null)
            {
                Debug.Log("projectile is null.");
                return;
            }
            BaseProjectileController projectileController = projectile.GetComponent<BaseProjectileController>();
            projectileController.Initialize(transform.position, direction);
            Debug.Log("NPC has shot a projectile.");
        }

        public void TakeDamage(float damage)
        {
            isBeingAttacked = true;
            //animator.SetBool("IsHurt", true);
            animator.SetTrigger("HurtTrigger");
            if (health > 0)
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
            //animator.SetBool("IsDead", true);
            animator.SetTrigger("DeadTrigger");
            health = maxHealth;
            isBeingAttacked = false;
            gameObject.SetActive(false);
            //NPCPoolManager.Instance.ReturnNPCToPool(npcName, gameObject);
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