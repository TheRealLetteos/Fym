using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


namespace fym
{
    public class PauseMenuController : AbstractMenuController
    {

        private Button resumeButton;

        private Button optionButton;

        private Button quitButton;

        // Start is called before the first frame update
        void Awake()
        {
            Initialize();
            resumeButton = rootMenuDocument.rootVisualElement.Q<Button>("ResumeButton");
            resumeButton.clicked += () => OnResumeClick();
            optionButton = rootMenuDocument.rootVisualElement.Q<Button>("OptionButton");
            optionButton.clicked += () => OnOptionClick();
            quitButton = rootMenuDocument.rootVisualElement.Q<Button>("QuitButton");
            quitButton.clicked += () => OnQuitGameClick();
        }

        private void OnQuitGameClick()
        {
            Debug.Log("Quit Game Clicked");
            MenuSystem.Instance.LoadQuitMenu();
        }

        private void OnOptionClick()
        {
            Debug.Log("Option Clicked");
            MenuSystem.Instance.LoadOptionMenu();
        }

        private void OnResumeClick()
        {
            Debug.Log("Option Clicked");
            Notify(GameEvent.Resuming);
        }
    }
}