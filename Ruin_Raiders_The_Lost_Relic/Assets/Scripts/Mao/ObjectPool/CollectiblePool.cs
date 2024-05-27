using fym;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePool : GameObjectPool<GameObject>
{
    public override GameObject GetObjectController(GameObject go)
    {
        throw new System.NotImplementedException();
    }
}
