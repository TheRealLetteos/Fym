using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
   [SerializeField] private BoxCollider2D _puzzle1;
   [SerializeField] private BoxCollider2D _puzzle2;
   [SerializeField] private BoxCollider2D _doorRb;
   [SerializeField] private SpriteRenderer _door;
   

   private void Update()
   {
      if (!_puzzle1.enabled && !_puzzle2.enabled)
      {
         _door.enabled = true;
         _doorRb.enabled = true;
      }
   }
}
