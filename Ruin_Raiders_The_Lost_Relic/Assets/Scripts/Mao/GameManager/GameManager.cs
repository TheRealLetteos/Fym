using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

namespace fym
{

    public class GameManager : AbstractStateMachine<GameState>
    {
        public static string CURRENT_SCENE { get; private set; } = "CurrentScene";

        public static string LOBBY_SCENE { get; private set; } = "LobbyScene";

        public static string SAMPLE_SCENE { get; private set; } = "Level3";

        public static string Loading_UI { get; internal set; } = "LoadingUI";
        
        public static string SECONDLEVEL_SCENE { get; private set; } = "Level2";

        public static string LEVELEDITOR_SCENE { get; private set; } = "NewLevelEditor";
        
        public static string LEVELHARDENER_SCENE { get; private set; } = "LevelHardener";

        public static string TAG_PLAYER { get; private set; } = "Player";

        public static string TAG_ENEMY { get; private set; } = "Enemy";

        public static string TAG_PROJECTILE { get; private set; } = "Projectile";

        public static string TAG_SOLIDTILE { get; private set; } = "SolidTile";
        
        public static string TAG_BREAKABLETILE { get; private set; } = "BreakableTile";

        public static string TAG_PICKUP { get; private set; } = "Pickup";

        public static string TAG_BOUNDARY { get; private set; } = "Boundary";

        public static string TAG_WATER { get; private set; } = "Water";

        public static string TAG_LETHALTRAP { get; private set; } = "LethalTrap";



        public static GameManager Instance { get; private set; }

        public static string FAIRY_POOL_NAME { get; private set; } = "Fairy";

        public static string SLIME_POOL_NAME { get; private set; } = "Slime";

        public static string MAGICBOLT_POOL_NAME { get; private set; } = "MagicBolt";

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
                new GameStateSecondLevel(this),
                new GameStateNextLevel(this),
                new GameStateRestartCurrentLevel(this),
                new GameStatePaused(this),
                new GameStateSceneEditor(this),
                new GameStateSceneLevelHardener(this),
                new GameStateEnd(this)
            };
        }

        public void RestartCurrentLevel()
        {
            LevelManager.Instance.LoadLevel(LevelManager.Instance.currentLevel);
        }

        public void LoadNextLevel()
        {
            LevelManager.Instance.IncreaseLevel();
            LevelManager.Instance.LoadLevel(LevelManager.Instance.currentLevel);
        }



    }

}