//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Tilemaps;
//// DONE:  Création de l'outil
//public class TilePlacementUndoRedoAction : MonoBehaviour, IUndoRedoAction
//{
//    private Tilemap tilemap;
//    private Vector3Int cellPosition;
//    private TileBase originalTile;
//    private TileBase newTile;

//    public void Initialize(Tilemap tilemap, Vector3Int cellPosition, TileBase originalTile, TileBase newTile)
//    {
//        this.tilemap = tilemap;
//        this.cellPosition = cellPosition;
//        this.originalTile = originalTile;
//        this.newTile = newTile;
//    }

//    public void Undo()
//    {
//        if (tilemap != null)
//        {
//            tilemap.SetTile(cellPosition, originalTile);
//        }
//    }

//    public void Redo()
//    {
//        if (tilemap != null)
//        {
//            tilemap.SetTile(cellPosition, newTile);
//        }
//    }
//}