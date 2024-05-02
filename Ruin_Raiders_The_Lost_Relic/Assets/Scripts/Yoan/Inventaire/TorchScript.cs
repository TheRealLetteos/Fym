using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{ 
    public class TorchScript : MonoBehaviour, IPickable, IUsableObject
    {
        [SerializeField] private InventoryScript _inventory;
        public void AddPickable()
        {
            _inventory._torch += 1;
        }
    
        public void Use()
        {
            _inventory._torch -= 1;
        }
    }   
}
