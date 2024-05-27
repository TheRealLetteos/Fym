using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    [Serializable]
    public class NamedGameObject<T>
    {

        public string name;

        public T gameObject;

    }
}