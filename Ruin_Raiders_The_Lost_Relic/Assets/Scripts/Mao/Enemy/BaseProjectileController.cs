using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{

    public class BaseProjectileController : MonoBehaviour
    {

        public float speed = 10;

        public float lifeTime = 2;

        public float damage = 1;

        public float range = 10;

        public Vector2 direction;

        public string ownerTag;

        private Rigidbody2D rb;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            string colliderTag = collision.gameObject.tag;

            if (colliderTag == GameManager.TAG_PLAYER && ownerTag != GameManager.TAG_PLAYER)
            {
                collision.gameObject.GetComponent<PlayerFSM>().TakeDamage(damage);
                gameObject.SetActive(false);
            }
            else if (colliderTag == GameManager.TAG_ENEMY && ownerTag != GameManager.TAG_ENEMY)
            {
                collision.gameObject.GetComponent<BaseEnemyController>().TakeDamage(damage);
                gameObject.SetActive(false);
            }
            else if (colliderTag == GameManager.TAG_SOLIDTILE || colliderTag == GameManager.TAG_BOUNDARY)
            {
                gameObject.SetActive(false);
            }
        }

        void FixedUpdate()
        {
            rb.velocity = direction * speed;
            lifeTime -= Time.fixedDeltaTime;
            if (lifeTime <= 0)
            {
                gameObject.SetActive(false);
            }
        }

    }
}