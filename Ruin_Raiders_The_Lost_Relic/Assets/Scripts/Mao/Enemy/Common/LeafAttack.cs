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
                Debug.Log("Target is null");
                return NodeResult.failure;
            }
            Debug.Log("Executing LeafAttack");
            Vector2 direction = targetTransform.Value.position - agentTransform.Value.position;
            direction.Normalize();
            BaseEnemyController baseEnemyController = agentTransform.Value.GetComponent<BaseEnemyController>();
            if (isRemoteAttack)
            {
                Debug.Log("Remote attack");
                baseEnemyController.Shoot(direction);
            }
            else
            {
                Debug.Log("Melee attack");
                baseEnemyController.Attack(targetTransform.Value.GetComponent<Player>());
            }
            return NodeResult.success;
        }
    }


}