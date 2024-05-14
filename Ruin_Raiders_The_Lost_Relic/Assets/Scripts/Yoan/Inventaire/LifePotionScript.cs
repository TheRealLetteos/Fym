using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace fym
{
    public class LifePotionScript : MonoBehaviour, IPickable, IUsableObject
    {
        [SerializeField] private InventoryScript _inventory;
        [SerializeField] private GameObject _potionButton;
        private Player _player;

        private void Start()
        {
            GameObject playerObject = GameObject.FindWithTag("Player");
            _player = playerObject.GetComponent<Player>();
        }

        public void AddPickable()
        {
            if (_inventory._lifePotion < 1)
            {
                _inventory._lifePotion += 1;
                _potionButton.SetActive(true);
            }
        }

        public void Use()
        {
            _player._life = 3;
            _player.UpdateHealth();
            _inventory._lifePotion -= 1;
            _potionButton.SetActive(false);
        }
    }
}
