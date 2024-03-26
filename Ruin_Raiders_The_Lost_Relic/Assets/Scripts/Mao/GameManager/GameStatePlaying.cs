using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class GameStatePaused : GameState
    {
        public GameStatePaused(GameManager stateMachine)
        {
            _fsm = stateMachine;
        }
    }
}
