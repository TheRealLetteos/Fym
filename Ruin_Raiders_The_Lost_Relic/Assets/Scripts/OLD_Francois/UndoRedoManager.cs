//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//// Attached to empty game object. Contient un stack (FIFO)
//public class UndoRedoManager : MonoBehaviour
//{
//    private Stack<IUndoRedoAction> undoStack = new Stack<IUndoRedoAction>();
//    private Stack<IUndoRedoAction> redoStack = new Stack<IUndoRedoAction>();

//    public void AddActionToUndoStack(IUndoRedoAction action)
//    {
//        undoStack.Push(action);
//        redoStack.Clear(); // Clear redo stack when a new action is added
//    }

//    public void Undo()
//    {
//        if (undoStack.Count > 0)
//        {
//            IUndoRedoAction action = undoStack.Pop();
//            action.Undo();
//            redoStack.Push(action);
//        }
//    }

//    public void Redo()
//    {
//        if (redoStack.Count > 0)
//        {
//            IUndoRedoAction action = redoStack.Pop();
//            action.Redo();
//            undoStack.Push(action);
//        }
//    }
//}