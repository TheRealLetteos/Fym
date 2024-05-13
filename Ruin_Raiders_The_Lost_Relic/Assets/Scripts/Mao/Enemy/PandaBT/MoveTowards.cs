using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace fym.ai.panda
{
    public class MoveTowards : BaseNPCPandaBTTaskNode
    {

        public float speed = 1.0f; // current speed

        public string destinationVector3Key;

        private BlackboardVector3 destinationPosition;

        public override void OnEnter()
        {
            base.OnEnter();
            destinationPosition = PandaBTBlackboard.Instance.GetVector3Ref(destinationVector3Key);
        }

        public void MoveTo()
        {
            Debug.Log("Executing LeafMoveNPC");
            Vector3 destination = destinationPosition.variableRef;
            Debug.Log("Target position: " + destination);
            Vector3 delta = destination - npcTransform.variableRef.position;

            Transform npc = npcTransform.variableRef;
            // Move as long as distance is greater than min. distance
            float dist = Vector2.Distance(destination, npc.position);
            if (dist > 0.001)
            {
                //ThisTask.debugInfo = "";
                //if (ThisTask.isInspected)
                //    ThisTask.debugInfo = string.Format("d={0:0.000}", dist);
                // Move towards target
                npc.position = Vector2.MoveTowards(
                    npc.position,
                    destination,
                    Mathf.Min(speed * Time.deltaTime, dist)
                );
            }
            else
            {
                //ThisTask.Succeed();
            }
            
        }

    }
}