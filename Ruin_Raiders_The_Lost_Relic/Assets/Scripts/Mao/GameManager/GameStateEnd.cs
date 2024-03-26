using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class GameStateEnd : GameState
    {
        public GameStateEnd(GameManager stateMachine)
        {
            _fsm = stateMachine;
        }
    }
}