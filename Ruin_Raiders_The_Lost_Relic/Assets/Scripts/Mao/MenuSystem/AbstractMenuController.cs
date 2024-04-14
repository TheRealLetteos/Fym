using fym;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace fym
{
    public abstract class AbstractMenuController : AbstractObservedObject
    {

        protected UIDocument rootMenuDocument;


        protected void Initialize()
        {
            rootMenuDocument = GetComponent<UIDocument>();
        }

        private void Start()
        {
            foreach (IObserver observer in GameManager.Instance.GetAllStates())
            {
                RegisterObserver(observer);
            }
        }

        public virtual void DeactivateMenu()
        {
            Debug.Log("deactivating menu");
            rootMenuDocument.rootVisualElement.style.display = DisplayStyle.None;
        }

        public virtual void ActivateMenu()
        {
            Debug.Log("activating menu");
            rootMenuDocument.rootVisualElement.style.display = DisplayStyle.Flex;
        }

    }
}