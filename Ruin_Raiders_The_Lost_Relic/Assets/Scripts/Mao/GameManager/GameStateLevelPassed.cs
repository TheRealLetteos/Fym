using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class GameStateLevelPassed : GameState
    {
        public GameStateLevelPassed(GameManager stateMachine) : base(stateMachine)
        {
        }

        public override void OnNotify(GameEvent e)
        {
            if (e == GameEvent.LevelPassed)
            {
                canEnter = true;
            }
        }

        public override void OnEnter()
        {
            base.OnEnter();
            AudioManager.Instance.PlayAudioClip("LevelPassed");
            MenuSystem.Instance.LoadLevelPassedMenu();
        }
    }
}