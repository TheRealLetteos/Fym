//using UnityEngine;
//using UnityEngine.UI;
//using System.IO;
//using System.Runtime.Serialization.Formatters.Binary;
//using UnityEngine.Tilemaps;
//using System;
//using UnityEngine.EventSystems;

//public class LevelEditor : MonoBehaviour
//{
//    public Tilemap tilemap;
//    public TileBase currentTile;
//    public InputField filePathInput;
//    private string BaseSavePath => System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MyGameLevels";
//    private CommandManager commandManager = new CommandManager();

//    private Camera mainCamera;

//    private void Awake()
//    {
//        mainCamera = Camera.main;
//    }

//    private void Start()
//    {

//        Directory.CreateDirectory(BaseSavePath);
//    }

//    private void Update()
//    {
//        if (Input.GetMouseButtonDown(0)) 
//        {
//            if (EventSystem.current.IsPointerOverGameObject())  // Checks if the mouse is over a UI element
//            {
//                return;  // If true, does nothing!
//            }
//            Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
//            Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);
//            cellPosition.z = 0;

//            ICommand placeTileCommand = new PlaceTileCommand(tilemap, currentTile, cellPosition);
//            commandManager.ExecuteCommand(placeTileCommand);
//        }

//        if (Input.GetKeyDown(KeyCode.A) )
//        {
//            commandManager.Undo();
//            Debug.Log("UNDO!");
//        }

//        if (Input.GetKeyDown(KeyCode.S) )
//        {
//            commandManager.Redo();
//            Debug.Log("REDO!!!!!");
//        }
//    }
//    public void SetTile(TileBase newTile)
//    {
//        currentTile = newTile;
//    }

//    public void SaveLevel()
//    {
//        string filename = filePathInput.text;
//        if (string.IsNullOrEmpty(filename))
//        {
//            Debug.LogError("No filename specified!");
//            return;
//        }

//        if (!filename.EndsWith(".dat"))
//        {
//            filename += ".dat";
//        }

//        string path = Path.Combine(BaseSavePath, filename);
//        LevelData levelData = new LevelData(); // Ini. the tile list

//        tilemap.CompressBounds();
//        foreach (var position in tilemap.cellBounds.allPositionsWithin)
//        {
//            TileBase tile = tilemap.GetTile(position);
//            if (tile != null)
//            {
//                // Added null check; this is a complicated bug that happens sometimes. To investigate more or move to json
//                if (levelData == null || levelData.tiles == null)
//                {
//                    Debug.LogError("levelData or levelData.tiles is null");
//                    return;
//                }
//                try
//                {
//                    levelData.tiles.Add(new TileInfo(position.x, position.y, position.z, tile.name));
//                }
//                catch (Exception ex)
//                {
//                    Debug.LogError("Failed to add tile info: " + ex);
//                    return;
//                }
//            }
//        }

//        BinaryFormatter formatter = new BinaryFormatter();
//        FileStream stream = new FileStream(path, FileMode.Create);
//        try
//        {
//            formatter.Serialize(stream, levelData);
//        }
//        finally
//        {
//            stream.Close();
//        } // Thank you, C# player's guide (the class' book)
//    }

//    public void LoadLevel()
//    {
//        string filename = filePathInput.text;
//        if (string.IsNullOrEmpty(filename))
//        {
//            Debug.LogError("No filename specified!");
//            return;
//        }

//        if (!filename.EndsWith(".dat")) // if player forgot the extension, add it. A level can thus be called "Level1" and will become Level1.dat. Case-sensitive!
//        {
//            filename += ".dat";
//        }

//        string path = Path.Combine(BaseSavePath, filename);

//        if (File.Exists(path))
//        {
//            BinaryFormatter formatter = new BinaryFormatter();
//            FileStream stream = new FileStream(path, FileMode.Open);

//            // Source: https://docs.unity3d.com/Packages/com.unity.serialization@2.0/manual/index.html
//            // Also: https://learn.microsoft.com/en-us/dotnet/api/system.runtime.serialization.formatters.binary.binaryformatter.serialize?view=net-8.0

//            LevelData levelData = null;
//            try
//            {
//                levelData = (LevelData)formatter.Deserialize(stream);
//            }
//            catch (Exception e)
//            {
//                Debug.LogError("Failed to deserialize: " + e.Message); 
//                return;
//            }
//            finally
//            {
//                stream.Close(); // make sure its always shut down no matter what
//            }

//            tilemap.ClearAllTiles(); // Clear existing tiles

//            if (levelData == null || levelData.tiles.Count == 0)
//            {
//                Debug.LogError("No tiles data found to load.");
//                return;
//            }

//            foreach (TileInfo info in levelData.tiles)  
//            {
//                Vector3Int position = new Vector3Int(info.posX, info.posY, info.posZ);
//                TileBase tile = Resources.Load<TileBase>("Tiles/" + info.tileType);
//                if (tile == null)
//                {
//                    Debug.LogError("Failed to load tile: " + info.tileType);
//                    continue;
//                }
//                tilemap.SetTile(position, tile);
//            }
//            Debug.Log("Level loaded successfully.");
//        }
//        else
//        {
//            Debug.LogError("File not found: " + path);
//        }
//    } // Sometimes in my sleep, I still see this file.........
//}