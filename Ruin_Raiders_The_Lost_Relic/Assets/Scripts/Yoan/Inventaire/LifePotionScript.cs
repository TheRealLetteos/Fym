using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class LifePotionScript : MonoBehaviour, IPickable, IUsableObject
    {
        [SerializeField] private InventoryScript _inventory;
        [SerializeField] private Player _player;
        public void AddPickable()
        {
            _inventory._lifePotion += 1;
        }

        public void Use()
        {
            _player._life = 3;
            _player.UpdateHealth();
            _inventory._lifePotion -= 1;
        }
    }
}
