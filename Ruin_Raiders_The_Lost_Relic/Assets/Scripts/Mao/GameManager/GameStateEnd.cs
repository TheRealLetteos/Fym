using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    //means quitting the game
    public class GameStateEnd : GameState
    {
        public GameStateEnd(GameManager stateMachine) : base(stateMachine)
        {
        }

        public override void OnNotify(GameEvent e)
        {
            if(e == GameEvent.Quitting)
            {
                canEnter = true;
            }
        }

        public override void OnEnter()
        {
            base.OnEnter();
            //dispose of all resources
            //destroy all objects
            //unload all scenes
            Application.Quit();
        }
    }
}