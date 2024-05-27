using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{

    public abstract class Playable<T> : MonoBehaviour where T : IConfigurable
    {

        public abstract void Play(T config);

    }

}