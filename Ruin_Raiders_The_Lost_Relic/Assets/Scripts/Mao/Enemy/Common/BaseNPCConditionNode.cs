using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBT
{
    /**
     * Since Behaviour Tree is more powerful than Finite State Machine, we can use it to control the enemy's animation as FSM does. 
     * each behaviour node can have its own animation key, and the animation key will be set to true when the node is entered and
     * set to false when the node is exited.
     * 
     */
    public abstract class BaseNPCConditionNode : Condition
    {

        // The transform of the enemy
        public TransformReference agentTransform;

        public TransformReference targetTransform;

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnExit()
        {
            base.OnExit();
        }

    }
}
