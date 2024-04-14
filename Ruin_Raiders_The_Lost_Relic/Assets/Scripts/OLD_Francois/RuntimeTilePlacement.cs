//using UnityEngine;
//using UnityEngine.Tilemaps;

//public class RuntimeTilePlacement : MonoBehaviour
//{
//    public Tilemap tilemap;
//    public UndoRedoManager undoRedoManager;
//    public TileBase tileToAdd;

//    // FOR SPRINT 2:
//    // TODO: Script should work with level editor.
//    // TODO: Fine a way to refer to in-game grid position to have live editing 
//    // TODO: Add player start  and end
//    // TODO: Add powerups/objects in design

//    private void Update()
//    {
//        if (Input.GetMouseButtonDown(0)) // TODO: Use the second mouse button for specific placement
//        {
//            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//            Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);

//            // Place the tile
//            PlaceTile(cellPosition);
//        }
//    }

//    private void PlaceTile(Vector3Int cellPosition)
//    {
//        TileBase originalTile = tilemap.GetTile(cellPosition);

//        // Si la tile change, sinon ça fait rien, se sauve une action
//        if (originalTile != tileToAdd)
//        {
//            tilemap.SetTile(cellPosition, tileToAdd);

           
//            TilePlacementUndoRedoAction undoRedoAction = gameObject.AddComponent<TilePlacementUndoRedoAction>();
//            undoRedoAction.Initialize(tilemap, cellPosition, originalTile, tileToAdd);
//            undoRedoManager.AddActionToUndoStack(undoRedoAction);
//        }
//    }
//}