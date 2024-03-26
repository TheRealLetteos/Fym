using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class PlayerStateDead : PlayerState
    {
        public PlayerStateDead(AbstractStateMachine<PlayerState> stateMachine) : base(stateMachine)
        {
        }
    }
}