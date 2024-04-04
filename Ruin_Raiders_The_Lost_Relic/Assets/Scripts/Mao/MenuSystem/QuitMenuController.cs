using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace fym
{
    public class QuitMenuController : MonoBehaviour
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
            Application.Quit();
        }

        private void OnNoClick()
        {
            Debug.Log("Cancel quit game");
            MenuSystem.Instance.LoadMainMenu();
        }

    }
}