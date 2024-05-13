using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fym;

namespace MBT
{
    [MBTNode("AI/Face Player If Needed")]
    [AddComponentMenu("")]
    public class LeafFacePlayer : BaseNPCLeafNode
    {
        public override NodeResult Execute()
        {
            //Debug.Log("Executing LeafFacePlayer");
            BaseEnemyController  enemy = agentTransform.Value.GetComponent<BaseEnemyController>();
            return NodeResult.success;
        }
    }
}