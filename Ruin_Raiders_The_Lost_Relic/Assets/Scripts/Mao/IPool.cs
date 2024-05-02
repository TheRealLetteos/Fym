using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace fym
{

    public interface IPool<T>
    {

        public void Reinitialize();

        public T GetObject();



    }
}