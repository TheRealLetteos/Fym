using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace fym
{
   public class ReloadScene : MonoBehaviour
   {
      public void ReloadCurrentScene()
      {
         Scene activeScene = SceneManager.GetActiveScene();

         SceneManager.LoadScene(activeScene.buildIndex);
      }
   }
}
