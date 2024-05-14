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
        private Animator animator;

        // The transform of the enemy
        public TransformReference agentTransform;

        public TransformReference targetTransform;

        // The key of the animation
        public string nodeAnimationKey = null;

        void Awake()
        {
            animator = agentTransform.Value.GetComponent<Animator>();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            if (animator != null && nodeAnimationKey != null)
            {
                animator.SetBool(nodeAnimationKey, true);
                animator.SetTrigger(nodeAnimationKey);
                Debug.Log("Animator has set key " + nodeAnimationKey + " to true");
            }
            else
            {
                Debug.LogError("Animator or nodeAnimationKey is null");
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            if (animator != null && nodeAnimationKey != null)
            {
                animator.SetBool(nodeAnimationKey, false);
                Debug.Log("Animator has set key " + nodeAnimationKey + " to false");
            }
            else
            {
                Debug.LogError("Animator or nodeAnimationKey is null");
            }
        }

    }
}
