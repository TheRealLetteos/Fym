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
            agentTransform.Value.GetComponent<BaseEnemyController>().gameObject.SetActive(false);
            return NodeResult.success;
        }
    }
}