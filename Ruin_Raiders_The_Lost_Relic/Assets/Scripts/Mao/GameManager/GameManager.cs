using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{

    public class GameManager : AbstractStateMachine<GameState>
    {

        public static GameManager Instance { get; private set; }

        protected override void Awake()
        {
            if (Instance == null)
            {
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
                new GameStateEnd(this)
            };
        }

    }

}