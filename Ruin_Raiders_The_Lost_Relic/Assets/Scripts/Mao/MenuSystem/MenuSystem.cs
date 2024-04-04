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
            /*mainMenu.gameObject.SetActive(true);
            optionMenu.gameObject.SetActive(false);
            quitMenu.gameObject.SetActive(false);*/
            DeactivateAllMenu();
            mainMenu.ActivateMenu();
            mainMenu.gameObject.SetActive(true);
        }

        public void LoadOptionMenu()
        {
            /*mainMenu.gameObject.SetActive(false);
            optionMenu.gameObject.SetActive(true);
            quitMenu.gameObject.SetActive(false);*/
            DeactivateAllMenu();
            optionMenu.ActivateMenu();
            optionMenu.gameObject.SetActive(true);
        }

        public void LoadQuitMenu()
        {
            /*mainMenu.gameObject.SetActive(false);
            optionMenu.gameObject.SetActive(false);
            quitMenu.gameObject.SetActive(true);*/
            DeactivateAllMenu();
            quitMenu.ActivateMenu();
            quitMenu.gameObject.SetActive(true);
        }

        public void DeactivateAllMenu()
        {
            mainMenu.DeactivateMenu();
            optionMenu.DeactivateMenu();
            quitMenu.DeactivateMenu();
            //mainMenu.gameObject.SetActive(false);
            //optionMenu.gameObject.SetActive(false);
            //quitMenu.gameObject.SetActive(false);

        }

    }
}