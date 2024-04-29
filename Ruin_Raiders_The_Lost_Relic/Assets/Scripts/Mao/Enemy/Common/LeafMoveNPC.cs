using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBT
{

    [MBTNode("AI/Move NPC")]
    [AddComponentMenu("")]
    public class LeafMoveNPC : BaseNPCLeafNode
    {

        public Vector2Reference targetPosition;
        public FloatReference movementRange;
        public FloatReference speed;
        public float minDistance = 0f;

        public override NodeResult Execute()
        {
            Vector2 target = targetPosition.Value;
            Transform obj = agentTransform.Value;
            float speed = this.speed.Value;
            // Move as long as distance is greater than min. distance
            float dist = Vector2.Distance(target, obj.position);
            if (dist > minDistance)
            {
                // Move towards target
                obj.position = Vector2.MoveTowards(
                    obj.position,
                    target,
                    Mathf.Min(speed * Time.deltaTime, dist)
                );
                return NodeResult.running;
            }
            else
            {
                return NodeResult.success;
            }
        }
    }
}