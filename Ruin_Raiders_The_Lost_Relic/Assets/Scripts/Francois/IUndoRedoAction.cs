using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface pour le command pattern undo/redo
public interface IUndoRedoAction
{
    void Undo();
    void Redo();
}