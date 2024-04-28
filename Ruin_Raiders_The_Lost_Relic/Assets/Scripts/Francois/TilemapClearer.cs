using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapClearer : MonoBehaviour
{
    public Tilemap tilemap;  

  
    public void ClearTilemap()
    {
        if (tilemap != null)
        {
            tilemap.ClearAllTiles();
            Debug.Log("Tilemap cleared!");
        }
        else
        {
            Debug.LogError("No tilemap assigned!");
        }
    }
}