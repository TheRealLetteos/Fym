using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MBT
{

    [MBTNode("AI/Selector Is In Range")]
    [AddComponentMenu("")]
    public class SelectorIsInRange : Selector
    {
        public TransformReference agentTransform;
        public TransformReference targetTransform;
        public float range = 10f;

        public override NodeResult Execute()
        {
            if (Vector3.Distance(agentTransform.Value.position, targetTransform.Value.position) < range)
            {
                return NodeResult.success;
            }
            return NodeResult.failure;
        }
        
    }
}