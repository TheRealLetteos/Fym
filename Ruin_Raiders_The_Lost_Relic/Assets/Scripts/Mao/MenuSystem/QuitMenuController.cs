using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace fym
{
    public class QuitMenuController : AbstractMenuController
    {

        private Button yesButton;

        private Button noButton;

        private void Awake()
        {
            Initialize();
            yesButton = rootMenuDocument.rootVisualElement.Q<Button>("YesButton");
            yesButton.clicked += () => OnYesClick();
            noButton = rootMenuDocument.rootVisualElement.Q<Button>("NoButton");
            noButton.clicked += () => OnNoClick();
        }

        private void OnYesClick()
        {
            Debug.Log("Confirm quit game");
            //leave the quit action to the GameManager because the
            //menu system should not have the privilege to quit the game
            //Application.Quit();
            Notify(GameEvent.Quitting);
        }

        private void OnNoClick()
        {
            Debug.Log("Cancel quit game");
            MenuSystem.Instance.LoadMainMenu();
        }

    }
}