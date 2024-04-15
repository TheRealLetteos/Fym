using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace fym
{
    public class GameStateLobby : GameState
    {
        public GameStateLobby(GameManager stateMachine) : base(stateMachine)
        {
        }

        public override void OnNotify(GameEvent e)
        {
            if(e == GameEvent.Lobby && !canEnter)
            {
                canEnter = true;
            }
        }

        public override bool CanEnter(IState currentState)
        {
            return base.CanEnter(currentState) && currentState.GetType() != GetType();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            MenuSystem.Instance.LoadMainMenu();
        }

        public override void OnExit()
        {
            base.OnExit();
            //SceneManager.UnloadSceneAsync(GameManager.LOBBY_SCENE);
        }
    }
}