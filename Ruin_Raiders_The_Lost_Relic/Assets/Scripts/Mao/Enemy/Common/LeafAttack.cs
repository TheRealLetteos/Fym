using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fym;

namespace MBT
{

    [MBTNode("AI/Attack")]
    [AddComponentMenu("")]
    public class LeafAttack : BaseNPCLeafNode
    {
        public bool isRemoteAttack;

        public override NodeResult Execute()
        {
            if(targetTransform.Value == null)
            {
                //Debug.Log("Target is null");
                return NodeResult.failure;
            }
            //Debug.Log("Executing LeafAttack");
            Vector2 direction = targetTransform.Value.position - agentTransform.Value.position;
            direction.Normalize();
            BaseEnemyController baseEnemyController = agentTransform.Value.GetComponent<BaseEnemyController>();
            if (isRemoteAttack)
            {
                //Debug.Log("Remote attack");
                if (baseEnemyController!= null) 
                {
                    baseEnemyController.Shoot(direction);
                }
                
                //StartCoroutine("Shoot", direction);
            }
            else
            {
                //Debug.Log("Melee attack");
                //baseEnemyController.Attack(targetTransform.Value.GetComponent<Player>());
                StartCoroutine("Attack");
            }
            return NodeResult.success;
        }

        IEnumerator Shoot(Vector2 dir)
        {
            yield return new WaitForSeconds(1.0f);
            agentTransform.Value.GetComponent<BaseEnemyController>().Shoot(dir);
        }

        IEnumerator Attack()
        {
            yield return new WaitForSeconds(1.0f);
            agentTransform.Value.GetComponent<BaseEnemyController>().Attack(targetTransform.Value.GetComponent<Player>());
        }

    }


}