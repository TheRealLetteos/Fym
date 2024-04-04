using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
// DONE: [FYM-140] Conception de l'outil et de ses éléments (scaling, rotate, undo/redo, etc)
public class LevelEditor : MonoBehaviour
{
    public Tilemap tilemap;
    public UndoRedoManager undoRedoManager;

    private TileBase selectedTile;
    
    void Start()
    {
               selectedTile = tilemap.GetTile(tilemap.cellBounds.min); // TODO: Add several pallets for different zones (Change with button 1-2-3-4...?)
    }

    void Update()
    {
      
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);
            PlaceTile(cellPosition);
        }
    }

    void PlaceTile(Vector3Int cellPosition)
    {
        TileBase originalTile = tilemap.GetTile(cellPosition);

      
        if (originalTile != selectedTile)
        {
            tilemap.SetTile(cellPosition, selectedTile);

            //  COMMAND PATTERN implementation; reify the object as done in prog avancee
            TilePlacementUndoRedoAction undoRedoAction = gameObject.AddComponent<TilePlacementUndoRedoAction>();
            undoRedoAction.Initialize(tilemap, cellPosition, originalTile, selectedTile);
            undoRedoManager.AddActionToUndoStack(undoRedoAction);
        }
    }
}