using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym.ai.panda
{

    public class InVisionRange : BaseNPCPandaBTTaskNode
    {


        public bool IsInRange()
        {
            Debug.Log("Checking if target is in range");
            bool ret = npcTransform.variableRef.GetComponentInChildren<ViewFieldController>().targetInRange;
            Debug.Log("SelectorIsInRange: " + ret);
            return ret;
        }

    }
}