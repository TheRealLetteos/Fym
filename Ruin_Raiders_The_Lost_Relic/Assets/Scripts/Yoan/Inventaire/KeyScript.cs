using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class KeyScript : MonoBehaviour, IPickable
    {
        [SerializeField] private InventoryScript _inventory;
        public void AddPickable()
        {
            _inventory._key += 1;
        }
    }
}
