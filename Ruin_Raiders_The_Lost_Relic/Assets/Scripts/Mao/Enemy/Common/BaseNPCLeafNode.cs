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
    public abstract class BaseNPCLeafNode : Leaf
    {
        
        // The animator of the enemy
        public Animator animator;

        // The transform of the enemy
        public TransformReference agentTransform;

        // The key of the animation
        public string nodeAnimationKey = null;

        public override void OnEnter()
        {
            base.OnEnter();
            if (animator != null && nodeAnimationKey != null)
            {
                animator.SetBool(nodeAnimationKey, true);
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            if (animator != null && nodeAnimationKey != null)
            {
                animator.SetBool(nodeAnimationKey, false);
            }
        }

    }
}
