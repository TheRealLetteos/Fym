using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class PlayerStateIdle : PlayerState
    {
        public PlayerStateIdle(AbstractStateMachine<PlayerState> stateMachine) : base(stateMachine)
        {
        }
    }
}