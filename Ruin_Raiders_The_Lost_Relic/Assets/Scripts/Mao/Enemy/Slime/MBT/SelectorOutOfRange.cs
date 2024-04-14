using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBT
{
    [MBTNode("AI/Selector Out of Range")]
    [AddComponentMenu("")]
    public class SelectorOutOfRange : Selector
    {
        public TransformReference agentTransform;
        public float border = 10f;

        public override NodeResult Execute()
        {
            if (agentTransform.Value.position.x < border || agentTransform.Value.position.x > Screen.width - border)
            {
                return NodeResult.success;
            }
            return NodeResult.failure;
        }
    }
}