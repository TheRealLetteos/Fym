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
                new GameStateMenu(this),
                new GameStatePlaying(this),
                new GameStatePause(this),
                new GameStateGameOver(this)
            };
        }

    }

}