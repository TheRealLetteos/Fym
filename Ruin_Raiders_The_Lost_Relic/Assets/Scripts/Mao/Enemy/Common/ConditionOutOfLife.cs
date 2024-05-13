using fym;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBT
{

    [MBTNode("AI/Is NPC Out Of Life")]
    [AddComponentMenu("")]
    public class ConditionOutOfLife : BaseNPCConditionNode
    {
        public override bool Check()
        {
            //Debug.Log("Checking if target is in range");
            bool ret = agentTransform.Value.gameObject.activeSelf &&
                        agentTransform.Value.GetComponent<BaseEnemyController>().IsDead();
            //Debug.Log("Enemy is dead? " + ret);
            return ret;
        }
        
    }
}