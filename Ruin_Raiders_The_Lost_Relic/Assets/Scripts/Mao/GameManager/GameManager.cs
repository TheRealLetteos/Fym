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
                new GameStatePaused(this),
                new GameStateSceneEditor(this),
                new GameStateSceneLevelHardener(this),
                new GameStateEnd(this)
            };
        }

        public void LoadScene(string oldSceneName, string sceneName, bool async)
        {
            if(async)
            {
                StartCoroutine("AsyncUnloadScene", oldSceneName);
                StartCoroutine("AsyncLoadScene", sceneName);
            }
            else
            {
                //StartCoroutine("AsyncUnloadScene", oldSceneName);
                //SceneManager.UnloadScene(oldSceneName);
                SceneManager.LoadScene(sceneName);
                //StartCoroutine("OnSceneLoaded");
                OnSceneLoaded();

                /*GameObject ground = GameObject.Find("Ground");
                LevelConfig config = LevelConfig.GetNextLevelConfig();
                config.screenWidth = ground.GetComponent<TilemapRenderer>().bounds.size.x;
                config.screenHeight = ground.GetComponent<TilemapRenderer>().bounds.size.y;
                BaseNPCSpawner.SpawnNPCs(config, ground.transform.position);*/
                //StartCoroutine("AsyncLoadScene", sceneName);
                //SceneManager.LoadScene(sceneName);
            }
        }

        public IEnumerable AsyncUnloadScene()
        {
            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            while (!asyncUnload.isDone)
            {
                yield return null;
            }
            Debug.Log("Scene " + SceneManager.GetActiveScene().name + " is unloaded");
        }

        public IEnumerable AsyncLoadScene(string sceneName)
        {
            LevelConfig levelConfig = LevelConfig.GetNextLevelConfig();
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(
                sceneName == null ? "Level " + levelConfig.levelNumber : sceneName,
                LoadSceneMode.Single);

            asyncLoad.allowSceneActivation = false;

            while (!asyncLoad.isDone)
            {
                /*if (asyncLoad.progress >= 0.95f)
                {
                    Debug.Log("Scene " + sceneName + " is loaded");
                    asyncLoad.allowSceneActivation = true;
                }*/

                yield return null;
            }
            asyncLoad.allowSceneActivation = true;

            Debug.Log("new level " + sceneName + " loaded...");
            StartCoroutine("OnSceneLoaded");
            //BaseNPCSpawner.SpawnNPCs(LevelConfig.GetNextLevelConfig());
        }

        public void OnSceneLoaded()
        {
            //yield return new WaitForSeconds(1);
            GameObject ground = GameObject.Find("/Grid/Background");
            LevelConfig config = LevelConfig.GetNextLevelConfig();
            config.screenWidth = ground.GetComponent<TilemapRenderer>().bounds.size.x;
            config.screenHeight = ground.GetComponent<TilemapRenderer>().bounds.size.y;
            BaseNPCSpawner.SpawnNPCs(config, ground.transform.position);
        }
    }

}