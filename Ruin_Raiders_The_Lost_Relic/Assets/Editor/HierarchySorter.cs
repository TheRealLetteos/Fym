using UnityEngine;
using UnityEditor;
using System.Linq;

public class HierarchySorter : EditorWindow
{
    [MenuItem("Tools/Sort Hierarchy By Name")]
    private static void SortHierarchy()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>()
            .Where(g => g.transform.parent == null)  // no parents
            .OrderBy(g => g.name)                    // sorting
            .ToArray();                              // array of all parent gameobjects that are not child

        // See: https://docs.unity3d.com/ScriptReference/EditorWindow.html

        for (int i = 0; i < allObjects.Length; i++)  
        {
            allObjects[i].transform.SetSiblingIndex(i);
        }
    }
}