using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fym;

namespace MBT
{
    [MBTNode("AI/Dead")]
    [AddComponentMenu("")]
    public class LeafDead : BaseNPCLeafNode
    {
        public override NodeResult Execute()
        {
            //Debug.Log("Executing LeafDead");
            agentTransform.Value.GetComponent<BaseEnemyController>().Die();
            return NodeResult.success;
        }
    }
}