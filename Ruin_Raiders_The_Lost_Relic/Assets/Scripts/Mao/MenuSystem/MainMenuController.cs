using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace fym
{
    public class MainMenuController : AbstractMenuController
    {
        private Button startButton;

        private Button optionButton;

        private Button quitButton;

        private void Awake()
        {
            Initialize();
            startButton = rootMenuDocument.rootVisualElement.Q<Button>("StartButton");
            startButton.clicked += () => OnStartGameClick();
            optionButton = rootMenuDocument.rootVisualElement.Q<Button>("OptionButton");
            optionButton.clicked += () => OnOptionClick();
            quitButton = rootMenuDocument.rootVisualElement.Q<Button>("QuitButton");
            quitButton.clicked += () => OnQuitGameClick();
        }

        public override void DeactivateMenu()
        {
            rootMenuDocument.rootVisualElement.style.display = DisplayStyle.None;
        }

        public override void ActivateMenu()
        {
            rootMenuDocument.rootVisualElement.style.display = DisplayStyle.Flex;

            Notify(GameEvent.Lobby);
        }

        private void OnQuitGameClick()
        {
            Debug.Log("Quit Game Clicked");
            MenuSystem.Instance.LoadQuitMenu();
        }

        private void OnStartGameClick()
        {
            Debug.Log("Start Game Clicked");
            //just notify the game manager to change the state
            //it's the game manager's job to load the scene
            //SceneManager.UnloadSceneAsync("LobbyScene");
            //SceneManager.LoadScene("SampleScene");
            //leave this op to the game play module
            Notify(GameEvent.Playing);
        }

        private void OnOptionClick()
        {
            Debug.Log("Option Clicked");
            MenuSystem.Instance.LoadOptionMenu();
        }
    }
}