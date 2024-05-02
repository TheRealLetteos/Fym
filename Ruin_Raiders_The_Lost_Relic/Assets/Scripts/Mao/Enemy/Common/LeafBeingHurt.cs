using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MBT
{

    [MBTNode("AI/Being Hurt")]
    [AddComponentMenu("")]
    public class LeafBeingHurt : BaseNPCLeafNode
    {
        public override NodeResult Execute()
        {
            return  NodeResult.success;
        }
    }
}