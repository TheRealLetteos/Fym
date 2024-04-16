using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBT
{

    [MBTNode("AI/Randomly Choose Target Position in Range And Move")]
    [AddComponentMenu("")]
    public class LeafRandomTargetPosition : Leaf
    {
        public FloatReference movementRange;// = new FloatReference(VarRefMode.DisableConstant);
        public Vector2Reference targetPosition;// = new Vector2Reference(VarRefMode.DisableConstant);
        public TransformReference agentTransform;// = new TransformReference();

        public override void OnEnter()
        {
            var pos = Random.insideUnitCircle * movementRange.Value;
            float x = pos.x + agentTransform.Value.position.x;
            float y = agentTransform.Value.position.y;
            targetPosition.Value = new Vector2(x, y);
        }

        public override NodeResult Execute()
        {
            //Debug.Log("On GeneratedPointAroundSelf execute");
            return NodeResult.success;
        }
    }
}