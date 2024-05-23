using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace fym
{

    /**
     * Deprecated
     */
    public interface IPool<T>
    {

        public void Reinitialize();

        public T GetObjectController(GameObject go);



    }
}