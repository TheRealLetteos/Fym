using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{

    /**
     * since we are using the new input system, the FSM is not necessary for controlling the player
     * but it is still useful for managing the player's state and the transitions between them so that
     * we can handle various events and conditions that may occur during the game
     **/
    public class PlayerFSM : AbstractStateMachine<PlayerState>
    {

        protected override void CreatePossibleStates()
        {
            m_possibleStates = new List<PlayerState>
            {
                new PlayerStateAttack(this),
                new PlayerStateClimb(this),
                new PlayerStateDead(this),
                new PlayerStateDoubleJump(this),
                new PlayerStateIdle(this),
                new PlayerStateJump(this),
                new PlayerStateRun(this)
            };
        }

    }

}


