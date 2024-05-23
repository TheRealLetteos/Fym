using fym;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class NPCPool : GameObjectPool<BaseEnemyController>
    {

        public int npcLevel;

        public override BaseEnemyController GetObjectController(GameObject go)
        {
            return go.GetComponent<BaseEnemyController>();
        }
    }
}