using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{

    public class BaseProjectileController : IPoolingObject
    {

        public float maxLifeTime = 3;

        public string projectileName;

        public float speed = 1;

        private float lifeTime = 0;

        public float damage = 1;

        public float range = 10;

        public Vector3 direction;

        public string ownerTag;
        public override void Initialize()
        {
            gameObject.SetActive(true);
            lifeTime = maxLifeTime;
        }

        public void Initialize(Vector3 position, Vector3 direction)
        {
            Initialize();
            lifeTime = maxLifeTime;
            gameObject.transform.position = position;
            this.direction = direction;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            string colliderTag = collision.gameObject.tag;

            if (colliderTag == GameManager.TAG_PLAYER && ownerTag != GameManager.TAG_PLAYER)
            {
                //collision.gameObject.GetComponent<PlayerFSM>().TakeDamage(damage);
                gameObject.SetActive(false);
            }
            else if (colliderTag == GameManager.TAG_ENEMY && ownerTag != GameManager.TAG_ENEMY)
            {
                //collision.gameObject.GetComponent<BaseEnemyController>().TakeDamage(damage);
                gameObject.SetActive(false);
            }
            else if (colliderTag == GameManager.TAG_SOLIDTILE || colliderTag == GameManager.TAG_BOUNDARY)
            {
                gameObject.SetActive(false);
            }
        }

        void Update()
        {
            //gameObject.transform.position += (Vector3)direction * speed * Time.deltaTime;
            gameObject.transform.Translate(direction * speed * Time.deltaTime, Space.World);
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0)
            {
                Debug.Log("projectile time's up.");
                //ProjectilePoolManager.Instance.ReturnProjectileToPool(projectileName, gameObject);
                gameObject.SetActive(false);
            }
        }

    }
}