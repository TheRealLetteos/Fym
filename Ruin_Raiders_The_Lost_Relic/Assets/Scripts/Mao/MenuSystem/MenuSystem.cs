using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace fym
{
    public class MenuSystem : MonoBehaviour
    {

        public static MenuSystem Instance;

        [SerializeField]
        private LoadingUIController loadingUI;

        [SerializeField]
        private MainMenuController mainMenu;

        [SerializeField]
        private OptionMenuController optionMenu;

        [SerializeField]
        private PauseMenuController pauseMenu;

        [SerializeField]
        private QuitMenuController quitMenu;

        [SerializeField]
        private LevelPassedMenuController levelPassedMenu;

        [SerializeField]
        private LevelFailedMenuController levelFailedMenu;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private void Start()
        {
            //LoadMainMenu();
            //LoadLoadingUI();
        }

        public void LoadLoadingUI()
        {
            DeactivateAllMenu();
            loadingUI.ActivateMenu();
            loadingUI.gameObject.SetActive(true);
        }

        public void LoadMainMenu()
        {
            DeactivateAllMenu();
            mainMenu.ActivateMenu();
            mainMenu.gameObject.SetActive(true);
        }

        public void LoadOptionMenu()
        {
            DeactivateAllMenu();
            optionMenu.ActivateMenu();
            optionMenu.gameObject.SetActive(true);
        }

        public void LoadPauseMenu()
        {
            DeactivateAllMenu();
            pauseMenu.ActivateMenu();
            pauseMenu.gameObject.SetActive(true);
        }

        public void LoadQuitMenu()
        {
            DeactivateAllMenu();
            quitMenu.ActivateMenu();
            quitMenu.gameObject.SetActive(true);
        }

        public void LoadLevelPassedMenu()
        {
            DeactivateAllMenu();
            levelPassedMenu.ActivateMenu();
            levelPassedMenu.gameObject.SetActive(true);
        }

        public void LoadLevelFailedMenu()
        {
            DeactivateAllMenu();
            levelFailedMenu.ActivateMenu();
            levelFailedMenu.gameObject.SetActive(true);
        }

        public void DeactivateAllMenu()
        {
            loadingUI.DeactivateMenu();
            mainMenu.DeactivateMenu();
            optionMenu.DeactivateMenu();
            pauseMenu.DeactivateMenu();
            quitMenu.DeactivateMenu();
            levelPassedMenu.DeactivateMenu();
            levelFailedMenu.DeactivateMenu();
        }

    }
}