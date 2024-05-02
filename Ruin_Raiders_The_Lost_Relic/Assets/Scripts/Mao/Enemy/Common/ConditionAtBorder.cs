using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBT
{
    [MBTNode("AI/Is NPC At Border")]
    [AddComponentMenu("")]
    public class ConditionAtBorder : BaseNPCConditionNode
    {
        public float border = 10f;

        public override bool Check()
        {
            if (agentTransform.Value.position.x < border || agentTransform.Value.position.x > Screen.width - border)
            {
                return true;
            }
            return false;
        }
    }
}
