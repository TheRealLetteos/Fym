using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

namespace fym
{

    public class LevelManager : MonoBehaviour
    {

        public const int MAX_LEVEL = 99;

        public const int MAX_ENEMY_COUNT = 49;

        public const int MAX_ENEMY_LEVEL = 99;

        public const float MAX_SPAWN_DENSITY = 0.3f;

        public const float MAX_SPAWN_RANGE = 20.0f;

        public const float MAX_SCREEN_WIDTH = 1920.0f;

        public const float MAX_SCREEN_HEIGHT = 1080.0f;

        public const float MAX_LEVEL_DIFFICULTY = 30;

        public static LevelManager Instance { get; private set; }

        public GameObject PlayerPrefab;

        public int currentLevel { get; private set; } = -1;

        public LevelConfig GetCurrentLevel { get { return GetLevelConfig(currentLevel); } }

        public LevelList allLevels;


        // Start is called before the first frame update
        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }

        private void Update()
        {
            /*if(isLevelLoading && !isLevelLoaded)
            {
                MenuSystem.Instance.UpdateLevelLoadingUI();
            }*/
        }

        public void Reset()
        {
            currentLevel = -1;
        }

        public void IncreaseLevel()
        {
            currentLevel++;
            if(currentLevel > MAX_LEVEL)
            {
                currentLevel = 0;
            }
        }

        public LevelConfig GetLevelConfig(int levelNumber)
        {
            return allLevels.GetLevelConfig(levelNumber);
        }

        public void LoadLevel(int levelNumber, bool syncCurrentLevel = true)
        {
            LevelConfig config = GetLevelConfig(levelNumber);
            if (config == null)
            {
                Debug.LogWarning("Level " + levelNumber + " not found in level list.");
                return;
            }

            //UnloadCurrentLevel();

            if (syncCurrentLevel)
            {
                currentLevel = levelNumber;
            }
            AudioManager.Instance.StopMusic();
            SceneManager.LoadScene(config.levelName, LoadSceneMode.Single);
            Debug.LogWarning("Loading level " + config.levelName + "...");
            AudioManager.Instance.PlayAudioClip(config.bgmName);

            MenuSystem.Instance.DeactivateAllMenu();
            GameManager.Instance.OnNotify(GameEvent.Playing);


        }

        public async void LoadLevelAsync(int levelNumber, bool syncCurrentLevel = true)
        {
            LevelConfig config = GetLevelConfig(levelNumber);
            if(config == null)
            {
                Debug.LogWarning("Level " + levelNumber + " not found in level list.");
                return;
            }

            //UnloadCurrentLevel();

            if(syncCurrentLevel)
            {
                currentLevel = levelNumber;
            }

            AudioManager.Instance.StopMusic();
            var scene = SceneManager.LoadSceneAsync(config.levelName, LoadSceneMode.Single);
            Debug.LogWarning("Loading level " + config.levelName + "...");
            scene.allowSceneActivation = false;

            MenuSystem.Instance.LoadLevelLoadingUI();

            do
            {
                await Task.Delay(100);
                MenuSystem.Instance.UpdateLevelLoadingUI(scene.progress);
            } while (scene.progress < 0.95f);

            await Task.Delay(1000);

            scene.allowSceneActivation = true;
            AudioManager.Instance.PlayAudioClip(config.bgmName);

            MenuSystem.Instance.DeactivateAllMenu();
            GameManager.Instance.OnNotify(GameEvent.Playing);


        }

        //bug exists here
        private void UnloadCurrentLevel()
        {
            /*LevelConfig conf = GetCurrentLevel;
            if (conf != null)
            {
                var res = SceneManager.UnloadSceneAsync(conf.levelName);
                if(res.isDone)
                {
                    Debug.LogWarning("Unloaded level " + conf.levelName);
                    AudioManager.Instance.StopMusic();
                }
            }*/
            var name = SceneManager.GetActiveScene().name;

            Debug.LogWarning("Unloading level " + name + "...");
            if ("LobbyScene" == name)
            {
                Debug.Log("Cannot unload lobby scene from level manager");
                return;
            }
            var res = SceneManager.UnloadSceneAsync(name);
            if (res == null || res.isDone)
            {
                Debug.LogWarning("Unloaded level " + name);
                AudioManager.Instance.StopMusic();
            }
        }

        /*private IEnumerator _LoadLevelAsync(LevelConfig levelConfig)
        {
            MenuSystem.Instance.DeactivateAllMenu();

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelConfig.levelPath,
                LoadSceneMode.Additive);

            asyncLoad.allowSceneActivation = false;

            while (!asyncLoad.isDone)
            {
                if (asyncLoad.progress >= 0.95f)
                {
                    Debug.Log("Level " + levelConfig.levelName + " is almost loaded");
                    asyncLoad.allowSceneActivation = true;
                }

                yield return null;
            }
            asyncLoad.allowSceneActivation = true;
            Debug.Log("new level " + levelConfig.levelPath + " loaded...");
            //BaseNPCSpawner.SpawnNPCs(LevelConfig.GetNextLevelConfig());
        }*/

        /*private IEnumerator _OnSceneLoadedAsync()
        {
            yield return new WaitForSeconds(1);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(GetCurrentLevel.levelName));
            LevelConfig config = GetCurrentLevel;
            GameObject ground = GameObject.FindWithTag("Boundary");
            config.screenWidth = ground.GetComponent<TilemapRenderer>().bounds.size.x;
            config.screenHeight = ground.GetComponent<TilemapRenderer>().bounds.size.y;
            BaseNPCSpawner.SpawnNPCs(config, ground.transform.position);
        }*/

    }
}