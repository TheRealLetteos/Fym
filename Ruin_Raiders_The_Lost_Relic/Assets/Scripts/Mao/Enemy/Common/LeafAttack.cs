<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fym;
=======
﻿//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
>>>>>>> main

//namespace MBT
//{

<<<<<<< HEAD
    [MBTNode("AI/Attack")]
    [AddComponentMenu("")]
    public class LeafAttack : BaseNPCLeafNode
    {
        public FloatReference attackRange;
        public FloatReference attackDamage;
        public FloatReference attackCooldown;
        public FloatReference attackDuration;
        public FloatReference attackSpeed;
        public BoolReference isRemoteAttack;

        public override NodeResult Execute()
        {
            Vector2 direction = agentTransform.Value.GetComponent<BaseEnemyController>().GetDirection();
            if(isRemoteAttack.Value)
            {
                agentTransform.Value.GetComponent<BaseEnemyController>().Shoot(direction);
            }
            else
            {
                agentTransform.Value.GetComponent<BaseEnemyController>().Attack(direction);
            }
            return NodeResult.success;
        }
    }
=======
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
>>>>>>> main


//}