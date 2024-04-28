using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Tilemaps;
using System;
using UnityEngine.EventSystems;
using System.Windows.Forms;
public class LevelEditorHardener : MonoBehaviour // modified version to allow loading of levels.
{
    public Tilemap tilemap;
    
    private string BaseSavePath => System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MyGameLevels";
    private CommandManager commandManager = new CommandManager();

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    

    private void Update()
    {
        
    }
    public void LoadLevel()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Data Files (*.dat)|*.dat";
        openFileDialog.DefaultExt = "dat";
        openFileDialog.InitialDirectory = BaseSavePath;
        openFileDialog.Title = "Open Level File";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string path = openFileDialog.FileName;

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            LevelData levelData = null;
            try
            {
                levelData = (LevelData)formatter.Deserialize(stream);
            }
            finally
            {
                stream.Close();
            }

            if (levelData != null)
            {
                tilemap.ClearAllTiles(); // Clear existing tiles

                foreach (TileInfo info in levelData.tiles)
                {
                    Vector3Int position = new Vector3Int(info.posX, info.posY, info.posZ);
                    TileBase tile = Resources.Load<TileBase>("Tiles/" + info.tileType);
                    if (tile != null)
                    {
                        tilemap.SetTile(position, tile);
                    }
                }
                Debug.Log("Level loaded: " + path);
            }
            else
            {
                Debug.LogError("Failed to load level data.");
            }
        }
    }
}