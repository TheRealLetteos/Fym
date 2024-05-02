using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBT
{

    [MBTNode("AI/Randomly Choose Target Position in Range And Move")]
    [AddComponentMenu("")]
    public class LeafRandomTargetPosition : BaseNPCLeafNode
    {
        public FloatReference movementRange;// = new FloatReference(VarRefMode.DisableConstant);
        public Vector2Reference targetPosition;// = new Vector2Reference(VarRefMode.DisableConstant);

        public override NodeResult Execute()
        {
            Debug.Log("Executing LeafRandomTargetPosition");
            var pos = Random.insideUnitCircle * movementRange.Value;
            float x = pos.x + agentTransform.Value.position.x;
            float y = agentTransform.Value.position.y;
            targetPosition.Value = new Vector2(x, y);
            return NodeResult.success;
        }
    }
}