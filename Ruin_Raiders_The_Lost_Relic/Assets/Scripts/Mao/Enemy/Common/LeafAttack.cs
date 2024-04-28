//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace MBT
//{

//    [MBTNode("AI/Attack")]
//    [AddComponentMenu("")]
//    public class LeafAttack : BaseEnemyLeafNode
//    {
//        public FloatReference attackRange;
//        public FloatReference attackDamage;
//        public FloatReference attackCooldown;
//        public FloatReference attackDuration;
//        public FloatReference attackSpeed;
//        public BoolReference isRemoteAttack;

//        public override NodeResult Execute()
//        {
//            if(isRemoteAttack.Value)
//            {
//                agentTransform.Value.GetComponent<Enemy>().RemoteAttack(attackRange.Value, attackDamage.Value, attackCooldown.Value, attackDuration.Value, attackSpeed.Value);
//            }
//            else
//            {
//                agentTransform.Value.GetComponent<Enemy>().Attack(attackRange.Value, attackDamage.Value, attackCooldown.Value, attackDuration.Value, attackSpeed.Value);
//            }
//        }
//    }


//}