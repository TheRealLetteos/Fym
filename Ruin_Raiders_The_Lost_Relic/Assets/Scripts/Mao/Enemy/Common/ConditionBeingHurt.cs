using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fym;

namespace MBT
{

    [MBTNode("AI/Is NPC Being Attacked")]
    [AddComponentMenu("")]
    public class ConditionBeingHurt : BaseNPCConditionNode
    {

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override bool Check()
        {
            return agentTransform.Value.GetComponent<BaseEnemyController>().IsBeingAttacked();
        }
    }
}