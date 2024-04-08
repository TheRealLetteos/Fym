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
        private MainMenuController mainMenu;

        [SerializeField]
        private OptionMenuController optionMenu;

        [SerializeField]
        private QuitMenuController quitMenu;

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
            DeactivateAllMenu();
            LoadMainMenu();
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

        public void LoadQuitMenu()
        {
            DeactivateAllMenu();
            quitMenu.ActivateMenu();
            quitMenu.gameObject.SetActive(true);
        }

        public void DeactivateAllMenu()
        {
            mainMenu.DeactivateMenu();
            optionMenu.DeactivateMenu();
            quitMenu.DeactivateMenu();

        }

    }
}