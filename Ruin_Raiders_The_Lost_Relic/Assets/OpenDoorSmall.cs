using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorSmall : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _puzzle1;
    [SerializeField] private BoxCollider2D _doorRb;
    [SerializeField] private GameObject _key;
    [SerializeField] private Renderer _doorMaterial;
    [SerializeField] private Material _newMaterial;
   

    private void Update()
    {
        if (!_puzzle1.enabled && _key.activeSelf)
        {
            _doorMaterial.material = _newMaterial;
            _doorRb.enabled = true;
        }
    }
}
