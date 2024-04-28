using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBT
{

    [MBTNode("AI/Being Hurt")]
    [AddComponentMenu("")]
    public class LeafBeingHurt : BaseEnemyLeafNode
    {
        public FloatReference hurtDuration;

        public override NodeResult Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}