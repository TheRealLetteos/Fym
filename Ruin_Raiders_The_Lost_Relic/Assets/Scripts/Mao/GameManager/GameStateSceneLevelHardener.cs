using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace fym
{


    public class GameStateSceneLevelHardener : GameState
    {
        //Yoan-----------------------------
        /*private AudioSource mainMenuAudio;

        private GameObject audioManager;*/

        //---------------------------------
        public GameStateSceneLevelHardener(GameManager stateMachine) : base(stateMachine)
        {
        }

        public override void OnNotify(GameEvent e)
        {
            if (e == GameEvent.LevelHarndenerScene)
            {
                canEnter = true;
            }
        }

        public override void OnEnter()
        {
            base.OnEnter();
            //Yoan---------------------------------------------------
            /*audioManager = GameObject.Find("/AudioManager/Music");
            mainMenuAudio = audioManager.GetComponent<AudioSource>();
            mainMenuAudio.Stop();*/
            AudioManager.Instance.StopMusic();
            //--------------------------------------------------------
            MenuSystem.Instance.DeactivateAllMenu();
            SceneManager.LoadScene("LevelHardener");
        }

        public override void OnExit()
        {
            base.OnExit();
            //SceneManager.LoadScene(GameManager.LOBBY_SCENE);
            GameManager.Instance.OnNotify(GameEvent.Lobby);
        }
    }
}
