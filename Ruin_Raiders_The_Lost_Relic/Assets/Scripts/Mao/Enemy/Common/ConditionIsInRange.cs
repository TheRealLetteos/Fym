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
            ViewFieldController viewFieldController = agentTransform.Value.GetComponentInChildren<ViewFieldController>();
            //Debug.Log("Checking if target is in range");
            bool ret = viewFieldController.targetInRange;
            if(ret)
            {
                targetTransform.Value = viewFieldController.targetTransform;
                //Debug.Log("Target is set to: " + targetTransform.Value);
            }
            //Debug.Log("SelectorIsInRange: " + ret);
            return ret;
        }
        
    }
}