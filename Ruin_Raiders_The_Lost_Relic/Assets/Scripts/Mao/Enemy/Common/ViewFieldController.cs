using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fym;

namespace MBT
{


    public class ViewFieldController : MonoBehaviour
    {

        public bool targetInRange { get; private set; } = false;

        public Transform targetTransform { get; private set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                //Debug.Log("Player entering vision");

                //commented for testing
                if (!Physics2D.Raycast(
                    transform.position,
                    collision.transform.position - transform.position,
                    Vector2.Distance(transform.position, collision.transform.position),
                    LayerMask.GetMask("Ground", "Water", "Enemy", "VisionRange", "Projectile", "Default")))
                {
                    //Debug.Log("Player layer detected");
                }
                targetInRange = true;
                targetTransform = collision.transform;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                //Debug.Log("Player exiting vision");
                targetInRange = false;
                targetTransform = null;
            }

        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                //Debug.Log("Player tag detected");
                /*if (!Physics2D.Raycast(
                    transform.position,
                    collision.transform.position - transform.position,
                    Vector2.Distance(transform.position, collision.transform.position),
                    LayerMask.GetMask("Ground", "Water", "Enemy", "VisionRange", "Projectile", "Default")))
                {
                    Debug.Log("Player layer detected");
                }*/
                //targetInRange = true;
            }

        }


    }
}