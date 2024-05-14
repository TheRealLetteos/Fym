using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace fym
{
    public class InventoryScript : MonoBehaviour
    {
        public int _coins{ get; set; }

        public int _key { get; set; }
        public int _artefact { get; set; }
        public int _torch { get; set; }
        public int _lifePotion { get; set; }

        [SerializeField] private GameObject _coinsUI;
        [SerializeField] private TextMeshProUGUI coinsText;

        private void Update()
        {
            if (_coins > 0)
            {
                _coinsUI.SetActive(true);
                coinsText.text = _coins.ToString();
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
