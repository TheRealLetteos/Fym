using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MBT
{
    [MBTNode("AI/Dead")]
    [AddComponentMenu("")]
    public class LeafDead : BaseEnemyLeafNode
    {
        public FloatReference deadDuration;

        public override NodeResult Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}