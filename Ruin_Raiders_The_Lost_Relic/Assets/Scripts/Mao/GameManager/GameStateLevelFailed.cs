using fym;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class GameStateLevelFailed : GameState
    {
        public GameStateLevelFailed(GameManager stateMachine) : base(stateMachine)
        {
        }

        public override void OnNotify(GameEvent e)
        {
            if (e == GameEvent.LevelFailed)
            {
                canEnter = true;
            }
        }

        public override void OnEnter()
        {
            base.OnEnter();
            //AudioManager.Instance.PlayAudioClip("LevelFailed");
            ProjectilePoolManager.Instance.ReturnProjectileToPool();
            NPCPoolManager.Instance.ReturnNPCToPool();
            MenuSystem.Instance.LoadLevelFailedMenu();
        }
    }
}