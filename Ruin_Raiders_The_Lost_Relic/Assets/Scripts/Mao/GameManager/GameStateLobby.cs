using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class GameStateLobby : GameState
    {
        public GameStateLobby(GameManager stateMachine)
        {
            _fsm = stateMachine;
        }
    }
}