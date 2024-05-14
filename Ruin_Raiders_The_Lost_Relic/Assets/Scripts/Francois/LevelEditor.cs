using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Tilemaps;
using System;
using UnityEngine.EventSystems;
using System.Windows.Forms;
using System.Collections.Generic;
public class LevelEditor : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase currentTile;
    public InputField filePathInput;
    private string BaseSavePath => System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MyGameLevels";
    private CommandManager commandManager = new CommandManager();

    private Camera mainCamera;

    //Level end and start
    public GameObject playerSpawnPrefab;
    public GameObject endSpawnPrefab;

    private GameObject currentPlayerSpawn;
    private GameObject currentEndSpawn;
    //public Dictionary<string, Vector3Int> specialPositions = new Dictionary<string, Vector3Int>();

    //End level end and start ;)

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Start()
    {

        Directory.CreateDirectory(BaseSavePath);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if (EventSystem.current.IsPointerOverGameObject())  // Checks if the mouse is over a UI element
            {
                return;  // If true, does nothing!
            }
            Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);
            cellPosition.z = 0;

            ICommand placeTileCommand = new PlaceTileCommand(tilemap, currentTile, cellPosition);
            commandManager.ExecuteCommand(placeTileCommand);
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (EventSystem.current.IsPointerOverGameObject())  // Checks if the mouse is over a UI element
            {
                return;  // If true, does nothing!
            }
            Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);
            cellPosition.z = 0;

            if (tilemap.HasTile(cellPosition))  // Check if there is a tile at the position
            {
                ICommand clearTileCommand = new ClearTileCommand(tilemap, cellPosition);
                commandManager.ExecuteCommand(clearTileCommand);
            }
        }


        // Undo Code
        if (Input.GetKeyDown(KeyCode.A) )
        {
            commandManager.Undo();
            Debug.Log("UNDO!");
        }

        // Redo code
        if (Input.GetKeyDown(KeyCode.S) )
        {
            commandManager.Redo();
            Debug.Log("REDO!!!!!");
        }
    }
    public void SetTile(TileBase newTile)
    {
        currentTile = newTile;
    }

    public void SaveLevel()
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Data Files (*.dat)|*.dat";
        saveFileDialog.DefaultExt = "dat";
        saveFileDialog.AddExtension = true;
        saveFileDialog.InitialDirectory = BaseSavePath;
        saveFileDialog.Title = "Save Level As";

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            string path = saveFileDialog.FileName;
            LevelData levelData = new LevelData();

            tilemap.CompressBounds();
            foreach (var position in tilemap.cellBounds.allPositionsWithin)
            {
                TileBase tile = tilemap.GetTile(position);
                if (tile != null)
                {
                    levelData.tiles.Add(new TileInfo(position.x, position.y, position.z, tile.name));
                }
            }

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);
            try
            {
                formatter.Serialize(stream, levelData);
            }
            finally
            {
                stream.Close();
            }
            Debug.Log("Level saved: " + path);
        }
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

    public void CreatePlayerSpawn()
    {
        Vector3 mouseWorldPos = GetMouseWorldPosition();

        if (currentPlayerSpawn != null)
        {
            Destroy(currentPlayerSpawn); // Remove the previous marker if it exists
        }

        currentPlayerSpawn = Instantiate(playerSpawnPrefab, mouseWorldPos, Quaternion.identity);
        Debug.Log("Player spawn created at: " + mouseWorldPos);
    }

    public void CreateEndSpawn()
    {
        Vector3 mouseWorldPos = GetMouseWorldPosition();

        if (currentEndSpawn != null)
        {
            Destroy(currentEndSpawn); // Remove the previous marker if it exists
        }

        currentEndSpawn = Instantiate(endSpawnPrefab, mouseWorldPos, Quaternion.identity);
        Debug.Log("End spawn created at: " + mouseWorldPos);
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}