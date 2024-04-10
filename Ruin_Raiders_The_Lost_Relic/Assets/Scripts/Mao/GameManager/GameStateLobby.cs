using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class GameStateLobby : GameState
    {
        public GameStateLobby(GameManager stateMachine) : base(stateMachine)
        {
        }

        public override void OnNotify(GameEvent e)
        {
            if(e == GameEvent.Lobby)
            {
                canEnter = true;
            }
        }
    }
}