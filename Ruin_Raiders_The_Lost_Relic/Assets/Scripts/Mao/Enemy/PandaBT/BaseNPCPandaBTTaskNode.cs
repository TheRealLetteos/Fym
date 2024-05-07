using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

namespace fym.ai.panda
{
    /**
     * Since Behaviour Tree is more powerful than Finite State Machine, we can use it to control the enemy's animation as FSM does. 
     * each behaviour node can have its own animation key, and the animation key will be set to true when the node is entered and
     * set to false when the node is exited.
     * 
     */
    public abstract class BaseNPCPandaBTTaskNode : MonoBehaviour
    {
        
        // The animator of the enemy
        public Animator animator;

        // The key of the animation
        public string nodeAnimationKey = null;

        public string npcTransformKey;

        public string targetTransformKey;

        protected BlackboardTransform npcTransform;

        protected BlackboardTransform targetTransform;

        [Task]
        public virtual void OnEnter()
        {
            if(npcTransformKey != null)
            {
                npcTransform = PandaBTBlackboard.Instance.GetTransformRef(npcTransformKey);
            }
            if(targetTransformKey != null)
            {
                targetTransform = PandaBTBlackboard.Instance.GetTransformRef(targetTransformKey);
            }
            if (animator != null && nodeAnimationKey != null)
            {
                animator.SetBool(nodeAnimationKey, true);
            }
        }

        [Task]
        public virtual void OnExit()
        {
            if (animator != null && nodeAnimationKey != null)
            {
                animator.SetBool(nodeAnimationKey, false);
            }
        }

    }
}
