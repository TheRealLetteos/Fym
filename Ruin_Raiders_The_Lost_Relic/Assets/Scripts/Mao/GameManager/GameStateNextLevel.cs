﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace fym
{

    //Deprecated
    public class GameStateNextLevel : GameState
    {

        private AudioSource mainMenuAudio;
        private GameObject audioManager;
        //---------------------------------
        public GameStateNextLevel(GameManager stateMachine) : base(stateMachine)
        {
        }

        public override void OnNotify(GameEvent e)
        {
            if (e == GameEvent.NextLevel)
            {
                canEnter = true;
            }
        }

        public override void OnEnter()
        {
            base.OnEnter();
            /*//Yoan---------------------------------------------------
            audioManager = GameObject.Find("/AudioManager/Music");
            mainMenuAudio = audioManager.GetComponent<AudioSource>();
            mainMenuAudio.Stop();
            //--------------------------------------------------------
            SceneManager.LoadScene("Level2");*/

            //AudioManager.Instance.StopMusic();
            GameManager.Instance.LoadNextLevel();
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }

}