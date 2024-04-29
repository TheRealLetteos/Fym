using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBT
{

    [MBTNode("AI/Turn Around and Move")]
    [AddComponentMenu("")]
    public class LeafTurnAround : BaseNPCLeafNode
    {

        public override void OnEnter()
        {
            Vector2 velocity = agentTransform.Value.GetComponent<Rigidbody2D>().velocity;
            Vector2 newVelocity = new Vector2(-velocity.x, velocity.y);
            agentTransform.Value.GetComponent<Rigidbody2D>().velocity = newVelocity;
            
        }

        public override NodeResult Execute()
        {
            return NodeResult.success;
        }
    }
}