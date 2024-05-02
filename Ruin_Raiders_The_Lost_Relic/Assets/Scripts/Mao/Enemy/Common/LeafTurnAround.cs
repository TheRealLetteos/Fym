using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fym;

namespace MBT
{

    [MBTNode("AI/Turn Around and Move")]
    [AddComponentMenu("")]
    public class LeafTurnAround : BaseNPCLeafNode
    {

        public override void OnEnter()
        {
            
        }

        public override NodeResult Execute()
        {
            Debug.Log("Executing LeafTurnAround");
            /*Vector2 velocity = agentTransform.Value.GetComponent<Rigidbody2D>().velocity;
            Vector2 direction = agentTransform.Value.GetComponent<BaseEnemyController>().GetDirection();
            Vector2 newVelocity = new Vector2(-velocity.x, velocity.y);
            Vector2 newDirection = new Vector2(-direction.x, direction.y);
            agentTransform.Value.GetComponent<Rigidbody2D>().velocity = newVelocity;
            agentTransform.Value.GetComponent<BaseEnemyController>().SetDirection(newDirection);*/
            return NodeResult.success;
        }
    }
}