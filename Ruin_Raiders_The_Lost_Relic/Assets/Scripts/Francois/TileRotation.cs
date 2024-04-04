using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Allows rotation of tiles in the editor
public class TileRotation : MonoBehaviour
{
  
    public void RotateClockwise()
    {
        transform.Rotate(Vector3.forward, -90f); // TODO: Add tile to level builder? To discuss with team
    }

 // DONE: Only allow 90 degree rotations
    public void RotateCounterClockwise()
    {
        transform.Rotate(Vector3.forward, 90f);
    }
}
