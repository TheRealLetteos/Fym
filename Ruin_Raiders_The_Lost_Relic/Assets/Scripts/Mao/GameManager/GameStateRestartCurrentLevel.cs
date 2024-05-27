using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{

    public class GameStateRestartCurrentLevel : GameState
    {
        public GameStateRestartCurrentLevel(GameManager gameManager) : base(gameManager)
        {
        }

        public override void OnNotify(GameEvent e)
        {
            if (e == GameEvent.RestartCurrentLevel)
            {
                canEnter = true;
            }
        }

        public override void OnEnter()
        {
            base.OnEnter();
            // Restart the current level
            GameManager.Instance.RestartCurrentLevel();
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }
    }

}