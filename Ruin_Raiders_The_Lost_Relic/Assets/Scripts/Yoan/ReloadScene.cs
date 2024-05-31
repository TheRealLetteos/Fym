using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace fym
{
   public class ReloadScene : MonoBehaviour
   {
        public GameManager gameManager;
        public void Start()
        {
            gameManager = GameManager.Instance;
        }
        public void ReloadCurrentScene()
      {

            gameManager.RestartCurrentLevel();

            //Scene activeScene = SceneManager.GetActiveScene();

            //SceneManager.LoadScene(activeScene.buildIndex);
      }
   }
}
