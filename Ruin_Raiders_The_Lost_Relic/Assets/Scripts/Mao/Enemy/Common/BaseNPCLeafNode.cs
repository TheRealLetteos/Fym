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
        public GameObjectReference animatorReference;

        private Animator animator;

        // The transform of the enemy
        public TransformReference agentTransform;

        public TransformReference targetTransform;

        // The key of the animation
        public string animationBoolKey = null;

        public string animationTriggerKey = null;

        void Start()
        {
            animator = animatorReference.Value.GetComponent<Animator>();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            if (animator != null)
            {
                if(animationBoolKey != null)
                {
                    animator.SetBool(animationBoolKey, true);
                    Debug.Log("Animator has set key " + animationBoolKey + " to true");
                }
                if(animationTriggerKey != null)
                {
                    animator.SetTrigger(animationTriggerKey);
                    Debug.Log("Animator has set trigger " + animationTriggerKey);
                }
            }
            else
            {
                //Debug.LogError("Animator or nodeAnimationKey is null");
                Debug.Log("Animator or nodeAnimationKey is null"); //changed for presentation
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            if (animator != null && animationBoolKey != null)
            {
                animator.SetBool(animationBoolKey, false);
                Debug.Log("Animator has set key " + animationBoolKey + " to false");
            }
        }

    }
}
