using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace fym
{
    public class GameStateSceneEditor : GameState
    {
        public GameStateSceneEditor(GameManager stateMachine) : base(stateMachine)
        {
        }

        public override void OnNotify(GameEvent e)
        {
            if (e == GameEvent.EditingScene)
            {
                canEnter = true;
            }
        }

        public override void OnEnter()
        {
            base.OnEnter();
            SceneManager.LoadScene("NewLevelEditor");
        }

        public override void OnExit()
        {
            base.OnExit();
            SceneManager.LoadScene(GameManager.LOBBY_SCENE);
        }
    }
}