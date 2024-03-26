using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class PlayerStateClimb : PlayerState
    {
        public PlayerStateClimb(AbstractStateMachine<PlayerState> stateMachine) : base(stateMachine)
        {
        }
    }
}