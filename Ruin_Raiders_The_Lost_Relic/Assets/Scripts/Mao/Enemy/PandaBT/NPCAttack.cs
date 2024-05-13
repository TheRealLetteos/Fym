using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym.ai.panda
{
    public class NPCAttack : BaseNPCPandaBTTaskNode
    {
        public bool isRemoteAttack;

        public void Attack()
        {
            Debug.Log("Executing LeafAttack");
            Vector2 direction =
                targetTransform.variableRef.position - npcTransform.variableRef.position;
            if(isRemoteAttack)
            {
                Debug.Log("Remote attack");
                npcTransform.variableRef.GetComponent<BaseEnemyController>().Shoot(direction);
            }
            else
            {
                Debug.Log("Melee attack");
                npcTransform.variableRef.GetComponent<BaseEnemyController>().Attack(
                    targetTransform.variableRef.GetComponent<Player>());
            }
            //ThisTask.Succeed();
        }
    }
}