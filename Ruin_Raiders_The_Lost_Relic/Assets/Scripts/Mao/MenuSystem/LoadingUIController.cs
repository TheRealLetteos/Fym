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

        [SerializeField]
        private bool ignoreInput = false;

        private void Awake()
        {
            Initialize();
            m_loadingProgress = rootMenuDocument.rootVisualElement.Q<ProgressBar>("ProgressBar");
            m_loadingProgress.RegisterValueChangedCallback((evt) => SetProgress(evt.newValue));
            Debug.Log("Progress bar is null? " + Equals(m_loadingProgress, null));
        }

        private void Update()
        {
            //if the game is loading, show the loading screen
            //if the game is not loading, detect any key press to start the game
            if (ignoreInput)
            {

                return;
            }
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
            else
            {
                
            }
        }

        public void SetProgress(float progress)
        {
            m_loadingProgress.value = progress;
        }

        public override void DeactivateMenu()
        {
            base.DeactivateMenu();
            SetProgress(0);
        }

    }
}