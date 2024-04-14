//using UnityEngine;
//using UnityEngine.UI;

//public class UndoButton : MonoBehaviour
//{
//     [SerializeField] private UndoRedoManager undoRedoManager; 

//    private Button undoButton;

//    void Start()
//    {
//        undoButton = GetComponent<Button>();
//        undoButton.onClick.AddListener(Undo);
//    }

//    void Undo()
//    {

        
//        if (undoRedoManager != null)
//        {
//            Debug.Log("Undo called!");
//            undoRedoManager.Undo();
//        }
//    }
//}