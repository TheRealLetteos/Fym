using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{

    public class GameManager : AbstractStateMachine<GameState>
    {

        public static string CURRENT_SCENE { get; private set; } = "CurrentScene";

        public static string LOBBY_SCENE { get; private set; } = "LobbyScene";

        public static string SAMPLE_SCENE { get; private set; } = "SampleScene";

        public static string Loading_UI { get; internal set; } = "LoadingUI";

        public static string LEVELEDITOR_SCENE { get; private set; } = "NewLevelEditor";

        public static GameManager Instance { get; private set; }

        protected override void Awake()
        {
            if (Instance == null)
            {
                base.Awake();
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        protected override void CreatePossibleStates()
        {
            m_possibleStates = new List<GameState>
            {
                new GameStateLoading(this),
                new GameStateLobby(this),
                new GameStatePlaying(this),
                new GameStatePaused(this),
                new GameStateSceneEditor(this),
                new GameStateEnd(this)
            };
        }


    }

}