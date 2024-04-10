using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace fym
{
    public class MainMenuController : AbstractObservedObject
    {
        private UIDocument mainMenuDocument;

        private Button startButton;

        private Button optionButton;

        private Button quitButton;

        private void Awake()
        {
            mainMenuDocument = GetComponent<UIDocument>();
            startButton = mainMenuDocument.rootVisualElement.Q<Button>("StartButton");
            startButton.clicked += () => OnStartGameClick();
            optionButton = mainMenuDocument.rootVisualElement.Q<Button>("OptionButton");
            optionButton.clicked += () => OnOptionClick();
            quitButton = mainMenuDocument.rootVisualElement.Q<Button>("QuitButton");
            quitButton.clicked += () => OnQuitGameClick();
            foreach (IObserver observer in GameManager.Instance.GetAllStates())
            {
                RegisterObserver(observer);
            }
        }

        public void DeactivateMenu()
        {
            mainMenuDocument.rootVisualElement.style.display = DisplayStyle.None;
        }

        public void ActivateMenu()
        {
            mainMenuDocument.rootVisualElement.style.display = DisplayStyle.Flex;

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
            SceneManager.UnloadSceneAsync("LobbyScene");
            SceneManager.LoadScene("SampleScene");
            //leave this op to the game play module
            //Notify(GameEvent.Playing);
        }

        private void OnOptionClick()
        {
            Debug.Log("Option Clicked");
            MenuSystem.Instance.LoadOptionMenu();
        }
    }
}