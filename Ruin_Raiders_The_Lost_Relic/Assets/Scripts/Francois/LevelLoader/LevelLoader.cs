using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Tilemaps;

public class LevelLoader : MonoBehaviour
{
    public Tilemap tilemap;
    public Dictionary<string, TileBase> tileTypes; // Associates string witth tilebase

    void Start()
    {
        LoadLevel("C:\\Users\\MainPC\\Documents\\a1.dat"); //default level, note the double \ please!
    }

    void LoadLevel(string filePath)
    {
        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);

            LevelData levelData = (LevelData)formatter.Deserialize(stream);
            stream.Close();

            foreach (TileInfo tileInfo in levelData.tiles)
            {
                Vector3Int position = new Vector3Int(tileInfo.posX, tileInfo.posY, tileInfo.posZ);
                TileBase tile = tileTypes[tileInfo.tileType];
                if (tile != null)
                {
                    tilemap.SetTile(position, tile);
                }
                else
                {
                    Debug.LogWarning("Tile type not found: " + tileInfo.tileType);
                }
            }
        }
        else
        {
            Debug.LogError("No level file found!");
        }
    }
}

