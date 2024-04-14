using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace fym
{
    public class GameStatePlaying : GameState
    {
        public GameStatePlaying(GameManager stateMachine) : base(stateMachine)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            //SceneManager.LoadSceneAsync(GameManager.CURRENT_SCENE);
            //SceneManager.UnloadSceneAsync(GameManager.LOBBY_SCENE);
            SceneManager.LoadScene(GameManager.SAMPLE_SCENE);
        }

        public override void OnExit()
        {
            base.OnExit();
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
