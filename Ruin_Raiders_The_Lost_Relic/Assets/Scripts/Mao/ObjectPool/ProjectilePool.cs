using fym;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class ProjectilePool : GameObjectPool<BaseProjectileController>
    {
        public override BaseProjectileController GetObjectController(GameObject go)
        {
            return go.GetComponent<BaseProjectileController>();
        }
    }
}