using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class GameStatePaused : GameState
    {
        public GameStatePaused(GameManager stateMachine) : base(stateMachine)
        {
        }

        public override void OnNotify(GameEvent e)
        {
            if(e == GameEvent.Pausing)
            {
                canEnter = true;
            }
        }
    }
}