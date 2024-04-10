using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace fym
{
    public class QuitMenuController : AbstractObservedObject
    {


        private UIDocument quitMenuDocument;

        private Button yesButton;

        private Button noButton;

        private void Awake()
        {
            quitMenuDocument = GetComponent<UIDocument>();
            yesButton = quitMenuDocument.rootVisualElement.Q<Button>("YesButton");
            yesButton.clicked += () => OnYesClick();
            noButton = quitMenuDocument.rootVisualElement.Q<Button>("NoButton");
            noButton.clicked += () => OnNoClick();
            foreach (IObserver observer in GameManager.Instance.GetAllStates())
            {
                RegisterObserver(observer);
            }
        }

        public void DeactivateMenu()
        {
            quitMenuDocument.rootVisualElement.style.display = DisplayStyle.None;
        }

        public void ActivateMenu()
        {
            quitMenuDocument.rootVisualElement.style.display = DisplayStyle.Flex;
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