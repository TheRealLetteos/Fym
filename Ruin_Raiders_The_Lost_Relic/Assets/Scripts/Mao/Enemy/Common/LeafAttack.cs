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
            Debug.Log("Executing LeafAttack");
            Vector2 direction = targetTransform.Value.position - agentTransform.Value.position;
            if(isRemoteAttack)
            {
                Debug.Log("Remote attack");
                agentTransform.Value.GetComponent<BaseEnemyController>().Shoot(direction);
            }
            else
            {
                Debug.Log("Melee attack");
                agentTransform.Value.GetComponent<BaseEnemyController>().Attack(targetTransform.Value.GetComponent<Player>());
            }
            return NodeResult.success;
        }
    }


}