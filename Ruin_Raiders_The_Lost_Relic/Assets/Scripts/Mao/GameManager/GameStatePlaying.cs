using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class GameStatePlaying : GameState
    {
        public GameStatePlaying(GameManager stateMachine)
        {
            _fsm = stateMachine;
        }
    }
}
