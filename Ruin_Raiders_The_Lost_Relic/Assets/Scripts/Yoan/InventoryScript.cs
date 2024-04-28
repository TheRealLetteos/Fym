using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class InventoryScript : MonoBehaviour
    {
        public int _coins { get; set; }
        public int _key { get; set; }
        public int _artefact { get; set; }
        public int _torch { get; set; }
        public int _lifePotion { get; set; }
        
        

        public void OnButtonClick(GameObject clickedButton)
        {
            IUsableObject UsableItem = clickedButton.gameObject.GetComponent<IUsableObject>();
            if (UsableItem != null)
            {
                UsableItem.Use();
            }
        }
    }
    
    public interface IPickable
    {
        void AddPickable();
    }

    public interface IUsableObject
    {
        void Use();
    }
}
