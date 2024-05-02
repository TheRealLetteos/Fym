using fym;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MBT
{

    [MBTNode("AI/Is Target In Range")]
    [AddComponentMenu("")]
    public class ConditionIsInRange : BaseNPCConditionNode
    {
        public override bool Check()
        {
            Debug.Log("Checking if target is in range");
            bool ret = agentTransform.Value.GetComponentInChildren<ViewFieldController>().targetInRange;
            Debug.Log("SelectorIsInRange: " + ret);
            return ret;
        }
        
    }
}