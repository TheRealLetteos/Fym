using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace fym
{

    public class LevelPassedMenuController : AbstractMenuController
    {
        
        private Button nextLevelButton;

        private Button mainMenuButton;

        void Awake()
        {
            Initialize();
            nextLevelButton = rootMenuDocument.rootVisualElement.Q<Button>("NextLevelButton");
            nextLevelButton.clicked += () => OnNextLevelClick();
            mainMenuButton = rootMenuDocument.rootVisualElement.Q<Button>("MainMenuButton");
            mainMenuButton.clicked += () => OnMainMenuClick();
        }

        private void OnMainMenuClick()
        {
            MenuSystem.Instance.LoadMainMenu();
        }

        private void OnNextLevelClick()
        {
            Notify(GameEvent.NextLevel);
        }

    }

}