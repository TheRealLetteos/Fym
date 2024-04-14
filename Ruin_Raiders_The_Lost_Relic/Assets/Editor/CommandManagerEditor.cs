using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(CommandManager))]
public class CommandManagerEditor : Editor  // Tool to print stack for debugging purpose in undo/redo
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CommandManager manager = (CommandManager)target;

        if (GUILayout.Button("Print Undo Stack"))
        {
            Debug.Log("Printing Undo Stack");
            PrintStack(manager.GetUndoStack()); 
            
        }

        if (GUILayout.Button("Print Redo Stack"))
        {
            Debug.Log("Printing REEEEdo Stack");
            PrintStack(manager.GetRedoStack()); 
        }
    }

    private void PrintStack(IEnumerable<ICommand> stack)
    {
        foreach (var command in stack)
        {
            Debug.Log(command.ToString());   // Print it!
        }
    }
}