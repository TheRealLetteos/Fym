using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class GameStateLoading : GameState
    {
        public GameStateLoading(GameManager stateMachine)
        {
            _fsm = stateMachine;
        }
    }
}