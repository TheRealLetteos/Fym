using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;
using TMPro;

namespace fym.ai.panda
{
    public class RandomDesination : BaseNPCPandaBTTaskNode
    {
        public string destinationVector3Key;

        private BlackboardVector3 destinationPosition;

        public float movementRange;

        public override void OnEnter()
        {
            base.OnEnter();
            destinationPosition = PandaBTBlackboard.Instance.GetVector3Ref(destinationVector3Key);
        }

        [Task]
        public void SetDestination()
        {
            Debug.Log("Executing LeafRandomTargetPosition");
            Vector2 npcPosition = npcTransform.variableRef.position;
            var pos = Random.insideUnitCircle * movementRange;
            float x = pos.x + npcPosition.x;
            float y = npcPosition.y;
            destinationPosition.variableRef = new Vector2(x, y);
            ThisTask.Succeed();
        }
    }
}