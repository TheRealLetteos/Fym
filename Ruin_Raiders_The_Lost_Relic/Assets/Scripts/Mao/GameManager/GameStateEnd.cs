using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class GameStateEnd : GameState
    {
        public GameStateEnd(GameManager stateMachine) : base(stateMachine)
        {
        }

        public override void OnNotify(GameEvent e)
        {
            if(e == GameEvent.Ending)
            {
                canEnter = true;
            }
        }
    }
}