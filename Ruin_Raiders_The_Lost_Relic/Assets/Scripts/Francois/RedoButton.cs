using UnityEngine;
using UnityEngine.UI;

public class RedoButton : MonoBehaviour
{
    public UndoRedoManager undoRedoManager; // TODO: Make those SerializedField for consistency

    private Button redoButton;

    void Start()
    {
        redoButton = GetComponent<Button>();
        redoButton.onClick.AddListener(Redo); // Command pattern
    }

    void Redo()
    {
        if (undoRedoManager != null)
        {
            Debug.Log("Redo called!");
            undoRedoManager.Redo();
        }
    }
}