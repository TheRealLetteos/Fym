using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    private Stack<ICommand> undoStack = new Stack<ICommand>();
    private Stack<ICommand> redoStack = new Stack<ICommand>();

    // public IEnumerable<ICommand> GetUndoStack() => undoStack; 
    // public IEnumerable<ICommand> GetRedoStack() => redoStack;

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        undoStack.Push(command);
        redoStack.Clear();
        Debug.Log("Command executed and added to undo stack, stack count: " + undoStack.Count);

    }

    public IEnumerable<ICommand> GetUndoStack()
    {
        return undoStack;
    }

    public IEnumerable<ICommand> GetRedoStack()
    {
        return redoStack;
    }

    public void Undo()
    {
        if (undoStack.Count > 0)
        {
            ICommand command = undoStack.Pop();
            command.Undo();
            redoStack.Push(command);
            Debug.Log("Command undone, redo stack count: " + redoStack.Count);
        }
        else
        {
            Debug.Log("Undo stack is empty.");
        }
    }
    public void Redo()
    {
        if (redoStack.Count > 0)
        {
            ICommand command = redoStack.Pop();
            command.Execute();
            undoStack.Push(command);
            Debug.Log("Command redone, undo stack count: " + undoStack.Count);
        }
        else
        {
            Debug.Log("Redo stack is empty.");
        }
    }

    public void PrintUndoStack()
    {
        foreach (var command in undoStack)
        {
            Debug.Log(command.ToString());
        }
    }

    public void PrintRedoStack()
    {
        foreach (var command in redoStack)
        {
            Debug.Log(command.ToString());
        }
    }
}