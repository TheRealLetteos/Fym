using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class GameStatePlaying : GameState
    {
        public GameStatePlaying(GameManager stateMachine) : base(stateMachine)
        {
        }

        public override void OnNotify(GameEvent e)
        {
            if(e == GameEvent.Playing)
            {
                canEnter = true;
            }
        }

    }
}
