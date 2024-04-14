using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.InputSystem.Utilities;

namespace fym
{
    public class LoadingUIController : AbstractMenuController
    {

        private ProgressBar m_loadingProgress;

        private bool m_anyKeyPressed = false;

        private void Awake()
        {
            Initialize();
            m_loadingProgress = rootMenuDocument.rootVisualElement.Q<ProgressBar>("ProgressBar");
        }

        private void Update()
        {
            //if the game is loading, show the loading screen
            //if the game is not loading, detect any key press to start the game
            if(m_anyKeyPressed)
            {
                return;
            }
            InputSystem.onAnyButtonPress.CallOnce(ctrl => OnAnykeyPressed());
        }

        protected void OnAnykeyPressed()
        {
            if(!m_anyKeyPressed)
            {
                Debug.Log("Any key pressed");
                m_anyKeyPressed = true;
                Notify(GameEvent.Lobby);
            }
        }

    }
}