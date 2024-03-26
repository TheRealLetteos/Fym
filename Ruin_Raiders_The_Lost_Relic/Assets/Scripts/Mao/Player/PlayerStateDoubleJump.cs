using fym;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class PlayerStateDoubleJump : PlayerState
    {
        public PlayerStateDoubleJump(AbstractStateMachine<PlayerState> stateMachine) : base(stateMachine)
        {
        }
    }
}