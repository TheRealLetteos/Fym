using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class GameStateLoading : GameState
    {
        public GameStateLoading(GameManager stateMachine) : base(stateMachine)
        {
        }

        public override void OnNotify(GameEvent e)
        {
            if(e == GameEvent.Loading)
            {
                canEnter = true;
            }
        }
    }
}