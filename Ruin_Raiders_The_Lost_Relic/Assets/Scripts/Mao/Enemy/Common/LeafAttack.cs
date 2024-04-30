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
        public FloatReference attackSpeed;
        public BoolReference isRemoteAttack;

        public override NodeResult Execute()
        {
            Vector2 direction = agentTransform.Value.GetComponent<BaseEnemyController>().GetDirection();
            if(isRemoteAttack.Value)
            {
                agentTransform.Value.GetComponent<BaseEnemyController>().Shoot(direction);
            }
            else
            {
                agentTransform.Value.GetComponent<BaseEnemyController>().Attack(direction);
            }
            return NodeResult.success;
        }
    }


}