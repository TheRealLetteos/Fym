//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Tilemaps;

//public class TileSelector : MonoBehaviour
//{
//    [SerializeField] private Tilemap tilemap;
//    [SerializeField] private RuntimeTilePlacement RuntimeTilePlacement;

//    // TODO: Fix this for in-game placement and undo/redo! See sprint 2!

//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0)) // See: leveleditor.cs
//        {
//            SelectTileAtMousePosition();
//        }
//    }

//    void SelectTileAtMousePosition()
//    {
//        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);
//        TileBase selectedTile = tilemap.GetTile(cellPosition);

//        // Check if a tile is clicked
//        if (selectedTile != null)
//        {
            
//            RuntimeTilePlacement.tileToAdd = selectedTile;
//        }
//        else
//        {
//            Debug.Log("Pas de tile sélectionnée!");
//        }
//    }
//}