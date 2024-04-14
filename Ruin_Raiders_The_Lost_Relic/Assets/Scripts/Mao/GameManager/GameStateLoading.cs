using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        public override void OnEnter()
        {
            base.OnEnter();
            MenuSystem.Instance.LoadLoadingUI();
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}