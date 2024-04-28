using UnityEngine.Tilemaps;
using UnityEngine;

public class ClearTileCommand : ICommand
{
    private Tilemap tilemap;
    private Vector3Int position;
    private TileBase originalTile;

    public ClearTileCommand(Tilemap tilemap, Vector3Int position)
    {
        this.tilemap = tilemap;
        this.position = position;
        this.originalTile = tilemap.GetTile(position); // Save the original tile in case of undo
    }

    public void Execute()
    {
        tilemap.SetTile(position, null); // Clear the tile
    }

    public void Undo()
    {
        tilemap.SetTile(position, originalTile); // Restore the original tile
    }
}