using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class PlayerStateJump : PlayerState
    {
        public PlayerStateJump(AbstractStateMachine<PlayerState> stateMachine) : base(stateMachine)
        {
        }
    }
}