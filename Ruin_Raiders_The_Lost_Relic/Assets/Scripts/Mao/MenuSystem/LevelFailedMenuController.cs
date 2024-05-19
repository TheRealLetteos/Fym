using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace fym
{

    public class LevelFailedMenuController : AbstractMenuController
    {
        
        private Button restartLevelButton;

        private Button mainMenuButton;

        void Awake()
        {
            Initialize();
            restartLevelButton = rootMenuDocument.rootVisualElement.Q<Button>("RestartLevelButton");
            restartLevelButton.clicked += () => OnRestartLevelClick();
            mainMenuButton = rootMenuDocument.rootVisualElement.Q<Button>("MainMenuButton");
            mainMenuButton.clicked += () => OnMainMenuClick();
        }

        private void OnMainMenuClick()
        {
            MenuSystem.Instance.LoadMainMenu();
        }

        private void OnRestartLevelClick()
        {
            Notify(GameEvent.RestartCurrentLevel);
        }

    }

}