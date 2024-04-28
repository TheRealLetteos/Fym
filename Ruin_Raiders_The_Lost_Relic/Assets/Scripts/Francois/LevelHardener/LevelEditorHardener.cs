using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Tilemaps;
using System;
using UnityEngine.EventSystems;
using System.Windows.Forms;
public class LevelEditorHardener : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase currentTile;
    public InputField filePathInput;
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
    
}