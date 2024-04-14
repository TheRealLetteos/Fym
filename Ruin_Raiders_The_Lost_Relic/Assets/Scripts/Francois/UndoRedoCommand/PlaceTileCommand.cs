using UnityEngine.Tilemaps;
using UnityEngine;

public class PlaceTileCommand : ICommand
{
    private Tilemap tilemap;
    private TileBase tile;
    private Vector3Int position;
    private TileBase oldTile;

    public PlaceTileCommand(Tilemap tilemap, TileBase tile, Vector3Int position)
    {
        this.tilemap = tilemap;
        this.tile = tile;
        this.position = position;
        this.oldTile = tilemap.GetTile(position); // Store the old tile for undo!
    }

    public void Execute()
    {
        Debug.Log($"Placing tile {tile.name} at {position}");
        tilemap.SetTile(position, tile);
        tilemap.RefreshTile(position);
    }

    public void Undo()
    {
        Debug.Log($"Undo placing tile at {position}");
        tilemap.SetTile(position, oldTile);
        Debug.Log("Tile reverted at position: " + position);
        tilemap.RefreshTile(position);
    }

    public override string ToString()
    {
        return $"PlaceTileCommand at position {position} with tile {tile.name}";
    }
}