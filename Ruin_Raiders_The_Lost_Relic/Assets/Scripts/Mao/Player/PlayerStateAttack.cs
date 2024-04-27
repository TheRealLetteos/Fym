using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace fym
{

    public class PlayerStateAttack : PlayerState
    {
        public PlayerStateAttack(AbstractStateMachine<PlayerState> stateMachine) : base(stateMachine)
        {
        }
    }

}