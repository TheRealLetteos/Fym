using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{

    public interface IObserver
    {

        public void OnNotify(IEvent e);

    }

}