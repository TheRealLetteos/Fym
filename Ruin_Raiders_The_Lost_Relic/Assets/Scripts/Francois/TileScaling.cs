using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Allows scaling of tiles, i.e. giant tiles (2x2, 4x3, etc.)
public class TileScaling : MonoBehaviour
{
    public void Scale(float scaleFactor)
    {
        transform.localScale *= scaleFactor; // TODO: Add scaling button to UI
    }
}